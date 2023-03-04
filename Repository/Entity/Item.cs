using System;
namespace Repository.Entity
{
	public class Item
	{
		public int Id { get; set; }
        public string COD { get; set; }
        public string Title { get; set; }
        public Dictionary<string, Color> colors = new Dictionary<string, Color>();

		public Item()
		{
			colors.Add("black", Color.Black);
			colors.Add("red", Color.Red);
			colors.Add("green", Color.Green);
		}

		public Color GetColor(string name)
		{
			Color color;
			colors.TryGetValue(name.ToLower(), out color);
			return color;
		}
    }
}

