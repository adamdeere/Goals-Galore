namespace GoalsGalore.Model;

public class StockItem
{
    public int StockItemID { get; set; }

    public string SKUCode { get; set; } = string.Empty;

    public string SKUDescription { get; set; } = string.Empty;

    public string GRN { get; set; } = string.Empty;  // Goods Received Note

    public string LocationCode { get; set; } = string.Empty;

    public string Batch { get; set; } = string.Empty;

    public string StockStatus { get; set; } = string.Empty;

    public double QtyFree { get; set; }  // Available quantity

    public double QtyAllocated { get; set; }  // Optional

    public double QtyOnHand => QtyFree + QtyAllocated; // Computed property

    public DateTime? ExpiryDate { get; set; }  // Optional, for perishable goods

    public DateTime? LastUpdated { get; set; }

    public string? Notes { get; set; }
}