-- Creating table 'Iso3166'
CREATE TABLE [dbo].[Iso3166] (
    [CountryId] nchar(2)  NOT NULL,
    [CountryTitle] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Iso3166_2'
CREATE TABLE [dbo].[Iso3166_2] (
    [SubdivisionId] nvarchar(10)  NOT NULL,
    [CountryId] nchar(2)  NOT NULL,
    [SubdivisionTitle] nvarchar(50)  NOT NULL
);
GO
