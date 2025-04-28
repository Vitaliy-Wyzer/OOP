using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab3 {
    public class Catalog {
        public IList<Item> Items { get; set; }
        public string ThematicDepartment { get; set; }

        public Catalog(IList<Item> items) {
            Items = items;
            ThematicDepartment = string.Empty;
        }
        public Catalog(string thematicDepartment, IList<Item> items) {
            Items = items;
            ThematicDepartment = thematicDepartment;
        }
        public void AddItem(Item item) {
            Items.Add(item);
        }
        public override string ToString() {
            string str = $"Thematic Department: {ThematicDepartment}\n";
            foreach (Item item in Items) {
                str += item.ToString();
            }
            return str;
        }
        public void ShowAllItems() {
            foreach (Item item in Items) {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
