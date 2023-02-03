namespace ArtificialLife
{
    public interface ISensibale
    {
        public EEntityType[] types { get; }
        public float Range { get; set; }
        public bool IsSensing();
    }
}
