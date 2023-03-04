using System;
using Repository.Entity;

namespace Repository.Models
{
	public class ItemDto
	{
        public int Id { get; set; }
        public string COD { get; set; }
        public string Title { get; set; }
        public Dictionary<string, Color> colors = new Dictionary<string, Color>();

        public ItemDto()
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

