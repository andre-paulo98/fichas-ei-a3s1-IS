using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ficha5_ServerBookstore {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceBookstore {

        /* [OperationContract]
         string GetData(int value);

         [OperationContract]
         CompositeType GetDataUsingDataContract(CompositeType composite);*/

        [OperationContract]
        void AddBook(Book newBook);

        [OperationContract]
        List<Book> GetBooks();

        [OperationContract]
        List<Book> GetBooksByCategory(BookCategory category);

        [OperationContract]
        Book GetBookByTitle(string title);

        [OperationContract]
        bool DeleteBook(string title);

    }

    [DataContract]
    public class Book {

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public BookCategory Category { get; set; }

    }

    public enum BookCategory {
        WEB,
        CHILDREN,
        SCIENCE,
        ROMANCE,
        BIOGRAPHIES,
        OTHER
    }
}
