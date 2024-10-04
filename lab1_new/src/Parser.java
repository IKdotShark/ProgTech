import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
class Address {
    private String city;
    private String country;

    public Address(String city, String country) {
        this.city = city;
        this.country = country;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    @Override
    public String toString() {
        return "\n\t -- city: " + city + " \n\t -- country: " + country ;
    }
}

class Publisher {
    private String name;
    private Address address;

    public Publisher(String name, Address address) {
        this.name = name;
        this.address = address;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    @Override
    public String toString() {
        return "\n\t - name: " + name + " \n\t - address: " + address;
    }
}

class Price {
    private String currency;
    private double amount;

    public Price(String currency, double amount) {
        this.currency = currency;
        this.amount = amount;
    }

    public String getCurrency() {
        return currency;
    }

    public void setCurrency(String currency) {
        this.currency = currency;
    }

    public double getAmount() {
        return amount;
    }

    public void setAmount(double amount) {
        this.amount = amount;
    }

    @Override
    public String toString() {
        return amount + " " + currency;
    }
}

class Book {
    private String id;
    private String title;
    private String author;
    private int year;
    private String genre;
    private Price price;
    private String format;
    private Publisher publisher;
    private String translator;
    private String isbn;
    private String awards;

    public Book(String id, String title, String author, int year, String genre, Price price,
                String format, Publisher publisher, String translator, String isbn, String awards) {
        this.id = id;
        this.title = title;
        this.author = author;
        this.year = year;
        this.genre = genre;
        this.price = price;
        this.format = format;
        this.publisher = publisher;
        this.translator = translator;
        this.isbn = isbn;
        this.awards = awards;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    public Price getPrice() {
        return price;
    }

    public void setPrice(Price price) {
        this.price = price;
    }

    public String getFormat() {
        return format;
    }

    public void setFormat(String format) {
        this.format = format;
    }

    public Publisher getPublisher() {
        return publisher;
    }

    public void setPublisher(Publisher publisher) {
        this.publisher = publisher;
    }

    public String getTranslator() {
        return translator;
    }

    public void setTranslator(String translator) {
        this.translator = translator;
    }

    public String getIsbn() {
        return isbn;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public String getAwards() {
        return awards;
    }

    public void setAwards(String awards) {
        this.awards = awards;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("------------------------------\n");
        sb.append("Book:\n\tid: ").append(id);

        String[] attributes = {"title", "author", "year", "genre", "price", "format", "publisher", "translator", "isbn", "awards"};

        for (String attribute : attributes) {
            switch (attribute) {
                case "title":
                    if (title != null && !title.isEmpty()) {
                        sb.append("\n\ttitle: ").append(title);
                    }
                    break;
                case "author":
                    if (author != null && !author.isEmpty()) {
                        sb.append("\n\tauthor: ").append(author);
                    }
                    break;
                case "year":
                    if (year != 0) {
                        sb.append("\n\tyear: ").append(year);
                    }
                    break;
                case "genre":
                    if (genre != null && !genre.isEmpty()) {
                        sb.append("\n\tgenre: ").append(genre);
                    }
                    break;
                case "price":
                    if (price != null) {
                        sb.append("\n\tprice: ").append(price);
                    }
                    break;
                case "format":
                    if (format != null && !format.isEmpty()) {
                        sb.append("\n\tformat: ").append(format);
                    }
                    break;
                case "publisher":
                    if (publisher != null) {
                        sb.append("\n\tpublisher: ").append(publisher);
                    }
                    break;
                case "translator":
                    if (translator != null && !translator.isEmpty()) {
                        sb.append("\n\ttranslator: ").append(translator);
                    }
                    break;
                case "isbn":
                    if (isbn != null && !isbn.isEmpty()) {
                        sb.append("\n\tisbn: ").append(isbn);
                    }
                    break;
                case "awards":
                    if (awards != null && !awards.isEmpty()) {
                        sb.append("\n\tawards: ").append(awards);
                    }
                    break;
                default:
                    break;
            }
        }

        return sb.toString();
    }
}


class Parser {
    private List<Book> books = new ArrayList<>();

    public void parse(String filePath) {
        try (BufferedReader br = new BufferedReader(new FileReader(filePath))) {
            String line;
            Book currentBook = null;
            Publisher currentPublisher = null;
            Address currentAddress = null;
            Price currentPrice = null;
            String awards = null;

            while ((line = br.readLine()) != null) {
                line = line.trim();

                switch (getElementType(line)) {
                    case "book":
                        String id = line.replaceAll(".*id=\"|\">", "").trim();
                        currentBook = new Book(id, "", "", 0, "", null, "", null, "", "", "");
                        break;
                    case "title":
                        String title = line.replaceAll("<title>|</title>", "").trim();
                        currentBook.setTitle(title);
                        break;
                    case "author":
                        String author = line.replaceAll("<author>|</author>", "").trim();
                        currentBook.setAuthor(author);
                        break;
                    case "year":
                        int year = Integer.parseInt(line.replaceAll("<year>|</year>", "").trim());
                        currentBook.setYear(year);
                        break;
                    case "genre":
                        String genre = line.replaceAll("<genre>|</genre>", "").trim();
                        currentBook.setGenre(genre);
                        break;
                    case "price":
                        String currency = line.replaceAll(".*currency=\"([^\"]+)\".*", "$1").trim();
                        double amount = Double.parseDouble(line.replaceAll(".*<price\\s+currency=\"[^\"]+\">([\\d.]+)</price>.*", "$1").trim());
                        currentPrice = new Price(currency, amount);
                        break;
                    case "format":
                        String format = line.replaceAll("<format>|</format>", "").trim();
                        currentBook.setFormat(format);
                        break;
                    case "isbn":
                        String isbn = line.replaceAll("<isbn>|</isbn>", "").trim();
                        currentBook.setIsbn(isbn);
                        break;
                    case "translator":
                        String translator = line.replaceAll("<translator>|</translator>", "").trim();
                        currentBook.setTranslator(translator);
                        break;
                    case "publisher":
                        currentPublisher = new Publisher("", null);
                        break;
                    case "publisher_name":
                        if (currentPublisher != null) {
                            String name = line.replaceAll("<name>|</name>", "").trim();
                            currentPublisher.setName(name);
                        }
                        break;
                    case "city":
                        String city = line.replaceAll("<city>|</city>", "").trim();
                        currentAddress = new Address(city, "");
                        break;
                    case "country":
                        String country = line.replaceAll("<country>|</country>", "").trim();
                        currentAddress.setCountry(country);
                        break;
                    case "end_address":
                        if (currentPublisher != null) {
                            currentPublisher.setAddress(currentAddress);
                        }
                        break;
                    case "end_publisher":
                        currentBook.setPublisher(currentPublisher);
                        break;
                    case "awards":
                        awards = "";
                        break;
                    case "award":
                        awards += line.replaceAll("<award>|</award>", "").trim() + ", ";
                        break;
                    case "end_awards":
                        currentBook.setAwards(awards != null ? awards.replaceAll(", $", "") : null);
                        break;
                    case "end_book":
                        if (currentBook != null) {
                            currentBook.setPrice(currentPrice);
                            books.add(currentBook);
                        }
                        break;
                    default:
                        break;
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    private static String getElementType(String line) {
        if (line.startsWith("<book")) return "book";
        if (line.startsWith("<title>")) return "title";
        if (line.startsWith("<author>")) return "author";
        if (line.startsWith("<year>")) return "year";
        if (line.startsWith("<genre>")) return "genre";
        if (line.startsWith("<price")) return "price";
        if (line.startsWith("<format>")) return "format";
        if (line.startsWith("<isbn>")) return "isbn";
        if (line.startsWith("<translator>")) return "translator";
        if (line.startsWith("<publisher>")) return "publisher";
        if (line.startsWith("<name>")) return "publisher_name";
        if (line.startsWith("<city>")) return "city";
        if (line.startsWith("<country>")) return "country";
        if (line.startsWith("</address>")) return "end_address";
        if (line.startsWith("</publisher>")) return "end_publisher";
        if (line.startsWith("<awards>")) return "awards";
        if (line.startsWith("<award>")) return "award";
        if (line.startsWith("</awards>")) return "end_awards";
        if (line.startsWith("</book>")) return "end_book";
        return "unknown";
    }

    public List<Book> getBooks() {
        return books;
    }
}
