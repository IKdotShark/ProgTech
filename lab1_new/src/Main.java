public class Main {
    public static void main(String[] args) {
        Parser parser = new Parser();
        parser.parse("random_structure_9.xml");

        for (Book book : parser.getBooks()) {
            /*System.out.println(book.toString());*/
            System.out.println("Book ID: " + book.getId());
            System.out.println("Title: " + book.getTitle());
            System.out.println("Author: " + book.getAuthor());
            System.out.println("Year: " + book.getYear());
            System.out.println("Genre: " + book.getGenre());
            System.out.println("Price: " + book.getPrice());
            System.out.println("Format: " + book.getFormat());
            System.out.println("Publisher: " + book.getPublisher());
            System.out.println("Translator: " + book.getTranslator());
            System.out.println("ISBN: " + book.getIsbn());
            System.out.println("Awards: " + book.getAwards());
        }
    }
}
