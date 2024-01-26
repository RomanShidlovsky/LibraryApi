namespace Domain.Errors;

public class DomainErrors
{
    public static readonly Error InternalError = new(
        "Error.InternalError",
        "Internal error.",
        500);
    
    public static readonly Error UnknownError = new(
        "Unknown.UnknownError",
        "Unknown error occured");
    
    public static class Author
    {
        public static readonly Error AuthorNotFound = new(
            "Author.NotFound",
            "Author not found.",
            404);
    }

    public static class Book
    {
        public static readonly Error BookNotFound = new(
            "Book.NotFound",
            "Book not found.",
            404);
        
        public static readonly Error IsbnConflict = new(
            "Book.IsbnConflict",
            "Book with provided ISBN already exists.",
            409);
    }

    public static class Genre
    {
        public static readonly Error GenreNotFound = new(
            "Genre.NotFound",
            "Genre not found.",
            404);

        public static readonly Error NameConflict = new(
            "Genre.NameConflict",
            "Genre with provided name already exists.",
            409);
    }
    
    public static class Role
    {
        public static readonly Error RoleNotFound = new(
            "Role.NotFound",
            "Role not found.",
            404);

        public static readonly Error NameConflict = new(
            "Role.NameConflict",
            "Role with provided name already exists.",
            409);
    }
    
    public static class Subscription
    {
        public static readonly Error SubscriptionNotFound = new(
            "Subscription.NotFound",
            "Subscription not found.",
            404);

        public static readonly Error BookAlreadyReturned = new(
            "Subscription.AlreadyReturned",
            "The book with the specified ID has already been returned.",
            400);
        
        public static readonly Error BookAlreadyTaken = new(
            "Subscription.AlreadyTaken",
            "The book with the specified ID has already been taken.",
            400);
    }

    public static class User
    {
        public static readonly Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "Invalid login or password.",
            401);

        public static readonly Error UserNotFound = new(
            "User.NotFound",
            "User not found.",
            404);

        public static readonly Error UsernameConflict = new(
            "User.UsernameConflict",
            "The requested username is already in use.",
            409);
    }
    
    
}