USE [master]
GO

CREATE DATABASE [SharpComptaBase] ON  PRIMARY 
( NAME = N'SharpComptaBase', FILENAME = N'c:\SharpCompta\Data\SharpComptaBase.mdf' , SIZE = 3000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SharpComptaBase_log', FILENAME = N'c:\SharpCompta\Data\SharpComptaBase_log.LDF' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)