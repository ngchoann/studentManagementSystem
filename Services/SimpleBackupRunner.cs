using System; using System.Diagnostics; using System.IO; using System.Text; using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    public static class SimpleBackupRunner
    {
        public static Task<(int Code, string Out, string Err)> RunAsync(string script, string dir, Action<string>? log = null) =>
            Run(script, string.IsNullOrWhiteSpace(dir) ? @"C:\OracleBackups\Datapump" : dir, $"-DirPath \"{dir}\"", log, "Backup script not found");

        public static Task<(int Code, string Out, string Err)> RunRestoreAsync(string script, string dump, string action = "TRUNCATE", Action<string>? log = null)
        {
            if (string.IsNullOrWhiteSpace(dump) || !File.Exists(dump)) throw new FileNotFoundException("Dump file not found", dump);
            return Run(script, dump, $"-DumpFile \"{dump}\" -TableExistsAction {action}", log, "Restore script not found");
        }

        static async Task<(int Code, string Out, string Err)> Run(string script, string path, string args, Action<string>? log, string err)
        {
            if (string.IsNullOrWhiteSpace(script) || !File.Exists(script)) throw new FileNotFoundException(err, script);
            var o = new StringBuilder(); var e = new StringBuilder();
            var psi = new ProcessStartInfo("powershell.exe", $"-NoProfile -ExecutionPolicy Bypass -File \"{script}\" {args}")
            { UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true, CreateNoWindow = true, StandardOutputEncoding = Encoding.UTF8, StandardErrorEncoding = Encoding.UTF8 };
            using var p = new Process { StartInfo = psi, EnableRaisingEvents = true };
            p.OutputDataReceived += (_, ev) => { if (ev.Data != null) { o.AppendLine(ev.Data); log?.Invoke(ev.Data); } };
            p.ErrorDataReceived += (_, ev) => { if (ev.Data != null) { e.AppendLine(ev.Data); log?.Invoke($"[!] {ev.Data}"); } };
            p.Start(); p.BeginOutputReadLine(); p.BeginErrorReadLine(); await p.WaitForExitAsync();
            return (p.ExitCode, o.ToString(), e.ToString());
        }
    }
}
