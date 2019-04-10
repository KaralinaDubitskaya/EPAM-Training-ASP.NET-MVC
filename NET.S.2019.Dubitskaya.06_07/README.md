# Days 06-08
### EPAM-Training-ASP.NET-MVC                                                                                                           
                                                                                                           
### Tasks:                                                                                                            
**1. Book service**

Create a *Book* class (ISBN, author, title, publisher, year of publication, number of pages, price).
Override all necessary methods of *Object( class.
Implement IComparable and IEquatable interfaces for *Book* class.
Create a *BookListService* class as a service to work with a collection of books with the following methods:
  - AddBook (adds a book if not exists in the collection, otherwise throws an exception);
  - RemoveBook (removes a book if it exists, otherwise throws an exception);
  - FindBookByTag (finds a book by a given criterio);
  - SortBooksByTag (sorts books by a given criterio).
  - Create a *BookListService* class to perform basic operations with a list of books, 
    which can be loaded and/or saved in a *BookListStorage*.
Test classes by a console application.
Use a binary file as storage. Only *BinaryReader* and *BinaryWriter* classes are allowed to work with. 
Do not use delegates.
    
**2. Bank service**

Develop a type system describing work with a bank account.
The state of the account is determined by its ID, account holder (name, surname), balance and bonus points. 
Bonus points increase / decrease each time the account is credited / debited by values.
Points integers and depend on accuont status, which could be Base, Gold, Platinum, etc.
Implement service that provides the following dunctionality:
  - Add a new bank account.
  - Withdraw some cash.
  - Deposit some cash.
  - Close an existing account.
Data must be stored in a binary file.
Test classes by a console application.
    
                                                                                                               
                                                                                                                                   
                                                                                                                                                                                                                                                                                          
Karalina Dubitskaya                                                                        
dubitskaya.karalina@gmail.com
