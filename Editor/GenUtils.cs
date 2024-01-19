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

            var process = _Run(
                _DOTNET,
                arguments,
                workingDir,
                true
            );

            #region 捕捉生成错误

            string processLog = process.StandardOutput.ReadToEnd();


            if (process.ExitCode != 0)
            {
                string errorPath = logPath + "/LubanGenLog" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt";
                File.WriteAllText(errorPath, processLog);
                Debug.LogError("Error  生成出现错误.日志路径:" + errorPath);
            }
            else
            {
                Debug.Log("生成成功");
            }

            #endregion

            AssetDatabase.Refresh();
        }

        private static Process _Run(string exe, string arguments, string workingDir = ".", bool waitExit = false)
        {
            try
            {
                bool redirectStandardOutput = true;
                bool redirectStandardError = true;
                bool useShellExecute = false;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    redirectStandardOutput = false;
                    redirectStandardError = false;
                    useShellExecute = true;
                }

                if (waitExit)
                {
                    redirectStandardOutput = true;
                    redirectStandardError = true;
                    useShellExecute = false;
                }

                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = arguments,
                    CreateNoWindow = true,
                    UseShellExecute = useShellExecute,
                    WorkingDirectory = workingDir,
                    RedirectStandardOutput = redirectStandardOutput,
                    RedirectStandardError = redirectStandardError,
                };

                Process process = Process.Start(info);

                if (waitExit)
                {
                    WaitForExitAsync(process).ConfigureAwait(false);
                }

                return process;
            }
            catch (Exception e)
            {
                throw new Exception($"dir: {Path.GetFullPath(workingDir)}, command: {exe} {arguments}", e);
            }
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