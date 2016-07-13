namespace Swan.Generators
{
    using System.Collections.Generic;

    public class DataContextViewModel
    {
        public DataContextViewModel()
        {
            this.Entities = new List<string>();
        }

        public string Namespace { get; set; }

        public ICollection<string> Entities { get; set; }
    }
}