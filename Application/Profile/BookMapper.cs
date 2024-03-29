﻿using Application.DTOs.Book;
using Application.Features.BookFeatures.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Profile;

public class BookMapper : AutoMapper.Profile
{
    public BookMapper()
    {
        CreateMap<CreateBookCommand, Book>();
        CreateMap<Book, BookViewModel>()
            .ReverseMap();
    }
}