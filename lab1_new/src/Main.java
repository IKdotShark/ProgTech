public class Main {
    public static void main(String[] args) {
        Parser parser = new Parser();
        parser.parse("random_structure_9.xml");

        for (Book book : parser.getBooks()) {
            System.out.println(book.toString());
        }
    }
}
