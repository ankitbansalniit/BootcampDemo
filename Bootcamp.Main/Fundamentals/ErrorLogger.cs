﻿
using System;

namespace BootcampDemo.Examples
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged;

        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error;

            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }
    }
}