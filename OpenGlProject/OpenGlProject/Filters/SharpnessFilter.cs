namespace OpenGlProject.Filters
{
    public class SharpnessFilter : BaseMatrixFilter
    {
        public override float[] Matrix => new float[9] { -1.0f, 0, 0, 0, 0, 0, 0, 0, 0 };

        public override int Corr => 0;

        public override int Coeff => 1;

        public override bool NeedCountCorrection => false;
    }
}
