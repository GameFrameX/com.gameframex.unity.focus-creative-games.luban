using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Luban.Editor
{
    internal static class GenUtils
    {
        internal static readonly string _DOTNET = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "dotnet.exe" : "dotnet";

        /// <summary>
        /// 获取项目路径
        /// </summary>
        public static string GetProjectPath
        {
            get { return new DirectoryInfo(Application.dataPath).Parent.FullName; }
        }

        private static bool RunCommand(string cmd, string workDir, string logHeader, bool showInfo)
        {
            bool isSuccess = true;
            Process process = new Process();
            try
            {
                string app = "bash";
                string arguments = "-c";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    app = "cmd.exe";
                    arguments = "/c";
                }

                ProcessStartInfo start = new ProcessStartInfo(app);

                process.StartInfo = start;
                start.Arguments = arguments + " \"" + cmd + "\"";
                start.CreateNoWindow = true;
                start.ErrorDialog = true;
                start.UseShellExecute = false;
                start.WorkingDirectory = workDir;

                start.RedirectStandardOutput = true;
                start.RedirectStandardError = true;
                start.RedirectStandardInput = true;
                // start.StandardOutputEncoding = s_Encoding;
                // start.StandardErrorEncoding = s_Encoding;

                process.OutputDataReceived += (sender, args) =>
                {
                    if (showInfo && !string.IsNullOrEmpty(args.Data))
                    {
                        if (args.Data.Contains("|ERROR|"))
                        {
                            Debug.LogError(args.Data);
                        }
                        else
                        {
                            Debug.Log(args.Data);
                        }
                    }
                };
                process.ErrorDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        isSuccess = false;
                        Debug.LogWarning($"{logHeader} : {args.Data}");
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
            catch (Exception e)
            {
                isSuccess = false;
                Debug.LogError(e);
            }
            finally
            {
                process.Close();
            }

            return isSuccess;
        }

        /// <summary>
        /// 生成执行
        /// </summary>
        /// <param name="arguments">参数</param>
        /// <param name="workingDir">工作路径</param>
        public static void Gen(string arguments, string workingDir = ".")
        {
            string logPath = GetProjectPath + "/Logs";
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            Debug.Log("生成命令:" + arguments);
            RunCommand(arguments, workingDir, "生成", true);

            AssetDatabase.Refresh();
        }

        private static async Task WaitForExitAsync(this Process self)
        {
            if (!self.HasExited)
            {
                return;
            }

            try
            {
                self.EnableRaisingEvents = true;
            }
            catch (InvalidOperationException)
            {
                if (self.HasExited)
                {
                    return;
                }

                throw;
            }

            var tcs = new TaskCompletionSource<bool>();

            void Handler(object s, EventArgs e) => tcs.TrySetResult(true);

            self.Exited += Handler;

            try
            {
                if (self.HasExited)
                {
                    return;
                }

                await tcs.Task;
            }
            finally
            {
                self.Exited -= Handler;
            }
        }
    }
}