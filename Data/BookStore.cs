using KnjiskiMoljac.Models;

namespace KnjiskiMoljac.Data;

public class BookStore
{
   public List<Book> Books { get; set; } = GetBooks();

   private static List<Book> GetBooks()
   {
      return new List<Book>
        {
           new Book
           {
              Id = 1,
              Title = "Tvrđava",
              Author = "Meša Selimović",
              IsFinished = false,
              ImageUrl = "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/trdjava_connectum.jpg"
           },
           new Book
           {
              Id = 2,
              Title = "C# 10 i .NET 6 moderan međuplatformsko programiranje",
              Author = "Mark J. Price",
              IsFinished = false,
              ImageUrl = "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/moderno_medjuplatformsko_c_net.jpg"
           },
           new Book
           {
              Id = 3,
              Title = "Muhamed Mujić - Mostarska zlatna kopačka",
              Author = "Dario Mehmedović",
              IsFinished = false,
              ImageUrl = "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/muhamed_mujic.jpg"
           },
           new Book
           {
              Id = 4,
              Title = "Staljingrad: Sudbonosna opsada 1942–1943.",
              Author = "Entoni Bivor",
              IsFinished = false,
              ImageUrl = "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/staljingrad_opsada.jpg"
           },
           new Book
           {
              Id = 5,
              Title = "Harry Potter i zatočenik Azkabana",
              Author = "Joanne K. Rowling",
              IsFinished = false,
              ImageUrl = "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/harry_potter_zatocenik_azkabana.jpg"
           }
        };
   }
}
