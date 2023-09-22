﻿using DataModel.Entities;
using System.Text.RegularExpressions;

namespace RequisitesFilter;

public static class Filter
{
    public static bool CheckLogin(string? input)
    {
        if (string.IsNullOrEmpty(input)) {  return false; }
        input = input.Trim();
        if (input[0] == '+')
        {
            if (input.Length != 15) { return false; }
            if (input[2] != '-' || input[6] != '-' || input[10] != '-') { return false; }
            if (   char.IsDigit(input[1])
                && char.IsDigit(input[3])
                && char.IsDigit(input[4])
                && char.IsDigit(input[5])
                && char.IsDigit(input[7])
                && char.IsDigit(input[8])
                && char.IsDigit(input[9])
                && char.IsDigit(input[11])
                && char.IsDigit(input[12])
                && char.IsDigit(input[13])
                && char.IsDigit(input[14]) ) { return true; } 
        }
        else if (input.Contains('@') && input.Contains('.'))
        {
            if (input.IndexOf('@') == 0) { return false; }
            if (input.IndexOf('.') == input.Length - 1) { return false; }
            if (input.IndexOf('.') - input.IndexOf('@') >= 2) { return true; }
        }
        else
        {
            foreach (char c in input.ToLower())
            {
                if (!(char.IsDigit(c) || (char.IsLetter(c) && 97 <= c && c <= 122)|| c == '_')) { return false; }
            }
            return true;
        }
        return false;
    }

    public static bool CheckPassword(string? password, string? confirm)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm)) { return false; }
        password = password.Trim();
        confirm = confirm.Trim();
        if (password.Length < 7) { return false; }
        bool hasChar = false;
        bool hasDigit = false;
        bool hasSymbol = false;
        foreach (char c in password)
        {
            if (char.IsLetter(c) && 1024 <= c && c <= 1279 && !hasChar) hasChar = true;
            if (char.IsDigit(c) && !hasDigit) hasDigit = true;
            if (char.IsPunctuation(c) && !hasSymbol) hasSymbol = true;
        }
        if (!hasChar || !hasDigit || !hasSymbol) { return false; }
        if (password.ToLower() == password || password.ToUpper() == password) { return false; }
        if (password != confirm) { return false; }
        return true;
    }
}