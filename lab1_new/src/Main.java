public class Main {
    public static void main(String[] args) {
        Parser parser = new Parser();
        parser.parse("random_structure_9.xml");

        for (Book book : parser.getBooks()) {
            System.out.println("---------------------------------------");
            if (book.getId() != null && !book.getId().isEmpty()) {
                System.out.println("Book ID: " + book.getId());
            }
            if (book.getTitle() != null && !book.getTitle().isEmpty()) {
                System.out.println("Title: " + book.getTitle());
            }
            if (book.getAuthor() != null && !book.getAuthor().isEmpty()) {
                System.out.println("Author: " + book.getAuthor());
            }
            if (book.getYear() != 0) {
                System.out.println("Year: " + book.getYear());
            }
            if (book.getGenre() != null && !book.getGenre().isEmpty()) {
                System.out.println("Genre: " + book.getGenre());
            }
            if (book.getPrice() != null) {
                System.out.println("Price: " + book.getPrice());
            }
            if (book.getFormat() != null && !book.getFormat().isEmpty()) {
                System.out.println("Format: " + book.getFormat());
            }
            if (book.getPublisher() != null) {
                System.out.println("Publisher: " + book.getPublisher());
            }
            if (book.getTranslator() != null && !book.getTranslator().isEmpty()) {
                System.out.println("Translator: " + book.getTranslator());
            }
            if (book.getIsbn() != null && !book.getIsbn().isEmpty()) {
                System.out.println("ISBN: " + book.getIsbn());
            }
            if (book.getAwards() != null && !book.getAwards().isEmpty()) {
                System.out.println("Awards: " + book.getAwards());
            }
        }

    }
}