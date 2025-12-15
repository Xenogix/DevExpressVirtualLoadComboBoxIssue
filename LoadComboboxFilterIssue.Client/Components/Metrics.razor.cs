using LoadComboboxFilterIssue.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoadComboboxFilterIssue.Client.Components
{
    public partial class Metrics : IDisposable
    {
        private MemorySnapshot? memory;
        private PeriodicTimer? _timer;
        private readonly CancellationTokenSource _cts = new();

        protected override void OnInitialized()
        {
            _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(500));
            _ = RunAutoRefreshAsync(_cts.Token);
        }

        private async Task RunAutoRefreshAsync(CancellationToken token)
        {
            try
            {
                while (_timer is not null && await _timer.WaitForNextTickAsync(token))
                {
                    await RefreshMemory();
                    await InvokeAsync(StateHasChanged);
                }
            }
            catch (OperationCanceledException)
            {
                // ignore cancellation
            }
        }

        async Task RefreshMemory()
        {
            var url = new Uri(new Uri(NavigationManager.BaseUri), "metrics/memory");
            memory = await HttpClient.GetFromJsonAsync<MemorySnapshot>(url);
        }

        static string FormatBytes(long bytes)
        {
            string[] sizes = ["B", "KB", "MB", "GB", "TB"];
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1) { order++; len = len / 1024; }
            return $"{len:0.##} {sizes[order]}";
        }

        public void Dispose()
        {
            _cts.Cancel();
            _timer?.Dispose();
            _cts.Dispose();
        }
    }
}