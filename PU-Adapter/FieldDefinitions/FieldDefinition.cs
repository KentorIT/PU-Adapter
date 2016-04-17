namespace Kentor.PU_Adapter.FieldDefinitions
{
    public class FieldDefinition
    {
        private readonly int startPosition;
        private readonly int length;

        public FieldDefinition(int startPosition, int length)
        {
            this.startPosition = startPosition;
            this.length = length;
        }

        public int StartPosition
        {
            get { return startPosition; }
        }
        public int Length
        {
            get { return length; }
        }
    }
}