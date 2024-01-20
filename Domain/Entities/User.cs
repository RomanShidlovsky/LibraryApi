﻿using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Subscription> Subscriptions { get; set; } = [];
    
}