using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lab3 {
    public class Library: IItemManagement {
        public string Address { get; set; }
        public IList<Librarian> Librarians { get; set; }
        public IList<Catalog> Catalogs { get; set; }
        public Library(string address, IList<Librarian> librarians, IList<Catalog> catalogs) {
            Address = address;
            Librarians = librarians;
            Catalogs = catalogs;
        }
        public void AddLibrarian(Librarian librarian) {
            Librarians.Add(librarian);
        }
        public void ShowAllLibrarians() {
            Console.WriteLine("Librarians:\n");
            foreach (Librarian librarian in Librarians) {
                Console.WriteLine(librarian.ToString());
            }
        }
        public void AddCatalog(Catalog catalog) {
            Catalogs.Add(catalog);
        }
        public void AddItem(Item item, string thematicDepartment) {
            foreach(Catalog catalog in Catalogs) {
                if (catalog.ThematicDepartment == thematicDepartment) {
                    catalog.AddItem(item);
                }
            }
        }
        public void ShowAllItems() {
            foreach(Catalog catalog in Catalogs) {
                catalog.ShowAllItems();
            }
        }
        public Item? FindItemBy(int id) {
            foreach (Catalog catalog in Catalogs) {
                Item? found = catalog.FindItemBy(id);
                if (found?.Id == id) {
                    return found;
                }
            }
            return null;
        }
        public Item? FindItemBy(string title) {
            foreach (Catalog catalog in Catalogs) {
                Item? found = catalog.FindItemBy(title);
                if (found?.Title == title) {
                    return found;
                }
            }
            return null;
        }
        public Item? FindItem(Expression<Func<Item, bool>> predicate) {
            foreach (Catalog catalog in Catalogs) {
                Item? found = catalog.FindItem(predicate);
                if (found is not null) {
                    return found;
                }
            }
            return null;
        }

        public override string ToString() {
            string lib = $"Adress: {Address}\n";
            lib += "Librarians:\n";
            foreach (Librarian librarian in Librarians) {
                lib += librarian.ToString();
            }
            lib += "Catalogs:\n";
            foreach (Catalog catalog in Catalogs) {
                lib += catalog.ToString();
            }
            return lib;
        }
    }
}
