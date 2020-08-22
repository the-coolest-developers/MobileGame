using System;

namespace Models.Items
{
    //Class for testing saving system
    [Serializable]
    class Item
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Cost { get; set; }

    }
}
