namespace CrustProductionViewer.Core.Models.Analysis
{
    public class ResourceFlow
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public float CurrentAmount { get; set; }
        public float MaxAmount { get; set; }
        public float InputRate { get; set; }  // Скорость производства
        public float OutputRate { get; set; } // Скорость потребления

        public float NetRate => InputRate - OutputRate;

        public float TimeToFill => OutputRate <= 0 ? float.MaxValue :
                                   (MaxAmount - CurrentAmount) / (InputRate - OutputRate);

        public float TimeToEmpty => InputRate >= OutputRate ? float.MaxValue :
                                    CurrentAmount / (OutputRate - InputRate);
    }
}
