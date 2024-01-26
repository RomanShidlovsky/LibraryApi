﻿namespace Domain.Errors;

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
        public static readonly Error AuthorNotFoundById = new(
            "Author.NotFoundById",
            "Author with specified id not found.",
            404);
    }

    public static class Book
    {
        public static readonly Error GenreNotAdded = new(
            "Book.GenreNotAdded",
            "Genre has not been added.",
            400);
        
        public static readonly Error GenreNotDeleted = new(
            "Book.GenreNotDeleted",
            "Genre has not been deleted.",
            400);
        
        public static readonly Error AuthorNotAdded = new(
            "Book.AuthorNotAdded",
            "Author has not been added.",
            400);
        
        public static readonly Error AuthorNotDeleted = new(
            "Book.AuthorNotDeleted",
            "Author has not been deleted.",
            400);
        
        public static readonly Error BookNotFoundById = new(
            "Book.NotFoundById",
            "Book with specified id not found.",
            404);
        
        public static readonly Error BookNotFoundByIsbn = new(
            "Book.NotFoundByIsbn",
            "Book with specified ISBN not found.",
            404);
        
        public static readonly Error IsbnConflict = new(
            "Book.IsbnConflict",
            "Book with provided ISBN already exists.",
            409);
    }

    public static class Genre
    {
        public static readonly Error GenreNotFoundById = new(
            "Genre.NotFoundById",
            "Genre with specified id not found.",
            404);

        public static readonly Error NameConflict = new(
            "Genre.NameConflict",
            "Genre with provided name already exists.",
            409);
    }
    
    public static class Role
    {
        public static readonly Error RoleNotFoundById = new(
            "Role.NotFoundById",
            "Role with specified id not found.",
            404);

        public static readonly Error NameConflict = new(
            "Role.NameConflict",
            "Role with provided name already exists.",
            409);
    }
    
    public static class Subscription
    {
        public static readonly Error SubscriptionNotFoundById = new(
            "Subscription.NotFoundById",
            "Subscription with specified id not found.",
            404);

        public static readonly Error BookAlreadyReturned = new(
            "Subscription.AlreadyReturned",
            "The book with the specified id has already been returned.",
            400);
        
        public static readonly Error BookAlreadyTaken = new(
            "Subscription.AlreadyTaken",
            "The book with the specified id has already been taken.",
            400);
    }

    public static class User
    {
        public static readonly Error RoleNotAdded = new(
            "User.RoleNotAdded",
            "Role has not been added.",
            400);
        
        public static readonly Error RoleNotDeleted = new(
            "User.RoleNotDeleted",
            "Role has not been deleted.",
            400);
        
        public static readonly Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "Invalid login or password.",
            401);

        public static readonly Error UserNotFoundById = new(
            "User.NotFoundById",
            "User with specified id not found.",
            404);
        
        public static readonly Error UserNotFoundByUsername = new(
            "User.NotFoundByUsername",
            "User with specified username not found.",
            404);

        public static readonly Error UsernameConflict = new(
            "User.UsernameConflict",
            "The requested username is already in use.",
            409);
    }
    
    
}