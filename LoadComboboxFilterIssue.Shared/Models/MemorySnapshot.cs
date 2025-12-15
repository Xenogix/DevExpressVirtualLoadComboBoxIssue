namespace LoadComboboxFilterIssue.Shared.Models
{
    public record MemorySnapshot(
        long WorkingSetBytes,
        long TotalAllocatedBytes
    );
}
