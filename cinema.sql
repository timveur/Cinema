USE [Cinema]
GO
/****** Object:  Table [dbo].[AgeLimits]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgeLimits](
	[IdAgeLimit] [int] IDENTITY(1,1) NOT NULL,
	[Limit] [nvarchar](3) NOT NULL,
 CONSTRAINT [PK_AgeLimits] PRIMARY KEY CLUSTERED 
(
	[IdAgeLimit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[IdCountry] [int] IDENTITY(1,1) NOT NULL,
	[NameCountry] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[IdCountry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Films]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Films](
	[IdFilm] [int] IDENTITY(1,1) NOT NULL,
	[NameFilm] [nvarchar](max) NOT NULL,
	[DescriptionFilm] [nvarchar](max) NULL,
	[IdAgeLimit] [int] NOT NULL,
	[Duration] [time](7) NOT NULL,
	[Actors] [nvarchar](max) NOT NULL,
	[FilmsCompany] [nvarchar](max) NULL,
	[FilmsDirectors] [nvarchar](max) NULL,
	[PhotoPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Films] PRIMARY KEY CLUSTERED 
(
	[IdFilm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmsCountries]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmsCountries](
	[IdFilmCountry] [int] IDENTITY(1,1) NOT NULL,
	[IdFilm] [int] NOT NULL,
	[IdCountry] [int] NOT NULL,
 CONSTRAINT [PK_FilmsCountries] PRIMARY KEY CLUSTERED 
(
	[IdFilmCountry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmsGenres]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmsGenres](
	[IdFilmGenre] [int] IDENTITY(1,1) NOT NULL,
	[IdFilm] [int] NOT NULL,
	[IdGenre] [int] NOT NULL,
 CONSTRAINT [PK_FilmsGenres] PRIMARY KEY CLUSTERED 
(
	[IdFilmGenre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formats]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formats](
	[IdFormat] [int] IDENTITY(1,1) NOT NULL,
	[Format] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Formats] PRIMARY KEY CLUSTERED 
(
	[IdFormat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[IdGenre] [int] NOT NULL,
	[NameGenre] [nvarchar](50) NOT NULL,
	[DescriptionGenre] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[IdGenre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleUsers]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUsers](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RoleUsers] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[IdSeat] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Decription] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_HallsSeats] PRIMARY KEY CLUSTERED 
(
	[IdSeat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[IdSession] [int] IDENTITY(1,1) NOT NULL,
	[IdFilm] [int] NOT NULL,
	[IdFormat] [int] NOT NULL,
	[DateSession] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[CostTicket] [money] NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[IdSession] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 08.12.2022 21:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[IdTicket] [int] IDENTITY(1,1) NOT NULL,
	[IdSession] [int] NOT NULL,
	[IdSeat] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[IdTicket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08.12.2022 21:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nchar](12) NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AgeLimits] ON 

INSERT [dbo].[AgeLimits] ([IdAgeLimit], [Limit]) VALUES (1, N'0+')
INSERT [dbo].[AgeLimits] ([IdAgeLimit], [Limit]) VALUES (2, N'6+')
INSERT [dbo].[AgeLimits] ([IdAgeLimit], [Limit]) VALUES (3, N'12+')
INSERT [dbo].[AgeLimits] ([IdAgeLimit], [Limit]) VALUES (4, N'16+')
INSERT [dbo].[AgeLimits] ([IdAgeLimit], [Limit]) VALUES (5, N'18+')
SET IDENTITY_INSERT [dbo].[AgeLimits] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (1, N'Австралия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (2, N'Австрия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (3, N'Азербайджан')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (4, N'Албания')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (5, N'Алжир')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (6, N'Андорра')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (7, N'Аргентина')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (8, N'Армения')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (9, N'Афганистан')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (10, N'Бангладеш‎')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (11, N'Белоруссия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (12, N'Бельгия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (13, N'Болгария')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (14, N'Боливия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (15, N'Ботсвана')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (16, N'Бразилия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (17, N'Великобритания')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (18, N'Венгрия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (19, N'Венесуэла')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (20, N'Вьетнам')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (21, N'Гаити‎')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (22, N'Гана')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (23, N'Гватемала')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (24, N'Германия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (25, N'Греция')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (26, N'Грузия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (27, N'Дания')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (28, N'Египет')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (29, N'Израиль')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (30, N'Индия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (31, N'Индонезия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (32, N'Ирак')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (33, N'Иран')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (34, N'Ирландия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (35, N'Исландия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (36, N'Испания')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (37, N'Италия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (38, N'Йемен')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (39, N'Казахстан')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (40, N'Камбоджа')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (41, N'Камерун')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (42, N'Канада')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (43, N'Кения')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (44, N'Киргизия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (45, N'Китай')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (46, N'КНДР')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (47, N'Колумбия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (48, N'ДР Конго')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (49, N'Кот д''Ивуар')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (50, N'Куба')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (51, N'Кувейт')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (52, N'Лаос')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (53, N'Латвия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (54, N'Ливан')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (55, N'Ливия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (56, N'Литва')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (57, N'Лихтенштейн')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (58, N'Люксембург')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (59, N'Маврикий')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (60, N'Мавритания')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (61, N'Мадагаскар')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (62, N'Малави')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (63, N'Малайзия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (64, N'Мали')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (65, N'Мальта')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (66, N'Марокко')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (67, N'Мексика')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (68, N'Мозамбик')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (69, N'Молдавия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (70, N'Монако')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (71, N'Монголия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (72, N'Намибия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (73, N'Непал')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (74, N'Нигер')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (75, N'Нигерия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (76, N'Нидерланды')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (77, N'Новая Зеландия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (78, N'Норвегия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (79, N'Пакистан')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (80, N'Палестина')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (81, N'Панама')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (82, N'Папуа-Новая Гвинея')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (83, N'Парагвай')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (84, N'Перу')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (85, N'Польша')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (86, N'Португалия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (87, N'Пуэрто-Рико')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (88, N'Россия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (89, N'Румыния')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (90, N'Северная Македония')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (91, N'Сенегал')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (92, N'Сербия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (93, N'Сингапур')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (94, N'Сирия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (95, N'Словакия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (96, N'Словения')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (97, N'Сомали')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (98, N'Судан')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (99, N'США')
GO
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (100, N'Таджикистан')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (101, N'Таиланд')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (102, N'Тайвань')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (103, N'Тунис')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (104, N'Туркмения')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (105, N'Турция')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (106, N'Узбекистан')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (107, N'Украина')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (108, N'Уругвай')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (109, N'Филиппины')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (110, N'Финляндия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (111, N'Франция')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (112, N'Хорватия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (113, N'Чад')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (114, N'Черногория')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (115, N'Чехия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (116, N'Чили')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (117, N'Швейцария')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (118, N'Швеция')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (119, N'Шри-Ланка')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (120, N'Эквадор')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (121, N'Эстония')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (122, N'Эфиопия')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (123, N'ЮАР')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (124, N'Республика Корея')
INSERT [dbo].[Countries] ([IdCountry], [NameCountry]) VALUES (125, N'Япония')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Films] ON 

INSERT [dbo].[Films] ([IdFilm], [NameFilm], [DescriptionFilm], [IdAgeLimit], [Duration], [Actors], [FilmsCompany], [FilmsDirectors], [PhotoPath]) VALUES (1, N'Анчартед: На картах не значится', N'Два искателя приключений Нейтан Дрейк и Виктор Салливан по прозвищу Салли отправляются на поиски величайшего сокровища мира. Кроме того, они надеются найти улики, которые приведут их к давно потерянному брату Нейтана.', 3, CAST(N'02:05:00' AS Time), N'Том Холланд, Марк Уолберг, София Тейлор Али, Антонио Бандерас, Тати Габриэль, Патриша Миден, Сара Жаклин, Петрик', N'Sony Pictures', N'Рубен Фляйшер', N'ancharted.jpg')
INSERT [dbo].[Films] ([IdFilm], [NameFilm], [DescriptionFilm], [IdAgeLimit], [Duration], [Actors], [FilmsCompany], [FilmsDirectors], [PhotoPath]) VALUES (2, N'Потустороннее', N'Город охватывает волна необъяснимых смертей. Во время расследования выясняется, что это как-то связано с найденной подростками старинной игрой, которая открыла мир для чего-то паранормального.', 4, CAST(N'01:36:00' AS Time), N'Элиз Левек, Вероника Феррес, Владимир Бурлаков, Джина Штибиц', N'Sky Films', N'Ву Лок Кван', N'potustoronnee.jpg')
INSERT [dbo].[Films] ([IdFilm], [NameFilm], [DescriptionFilm], [IdAgeLimit], [Duration], [Actors], [FilmsCompany], [FilmsDirectors], [PhotoPath]) VALUES (3, N'Волк и лев', N'Юная пианистка Альма возвращается в дом, где прошло её детство. Однажды она находит маленьких волчонка и львёнка, которые оказались одни в дикой природе. Альма спасает их и в тайне оставляет в своем доме. Они взрослеют вместе, и кажется, что их дружбу ничто не может разрушить. Но однажды их секрет раскрывают. Львенка ловят и отправляют в бродячий цирк, а волчонка забирают для исследований учёные. Теперь всем троим придётся отправиться в невероятное и опасное путешествие, чтобы вновь обрести семью.', 2, CAST(N'01:50:00' AS Time), N'Молли Кунц, Грэм Грин, Чарли Каррик, Дерек Джонс, Риз Слэк', N'StudioCanal', N'Жиль Де Мэтр', N'leloupetlelion.jpg')
INSERT [dbo].[Films] ([IdFilm], [NameFilm], [DescriptionFilm], [IdAgeLimit], [Duration], [Actors], [FilmsCompany], [FilmsDirectors], [PhotoPath]) VALUES (4, N'Наёмник', N'Служба в армии с детства была мечтой Джеймса Рида, а зеленый берет — предметом гордости. Но после полученных ранений он остается не у дел: в мирном обществе ему нет места, а состояние здоровья приходится поддерживать медикаментами, не всегда самыми «чистыми». И когда подворачивается возможность снова взяться за старое ремесло, бывший солдат не медлит. Но теперь выбор, на кого направить оружие, лежит полностью на нем.', 5, CAST(N'01:55:00' AS Time), N'Крис Пайн, Бен Фостер, Гиллиан Джейкобс, Эдди Марсан, Фарес Фарес, Нина Хосс, Джей Ди Пардо, Кифер Сазерленд, Тейт Флетчер, Флориан Мунтяну', N'Paramount Pictures', N'Тарик Салех', N'naemnik2022.jpg')
INSERT [dbo].[Films] ([IdFilm], [NameFilm], [DescriptionFilm], [IdAgeLimit], [Duration], [Actors], [FilmsCompany], [FilmsDirectors], [PhotoPath]) VALUES (5, N'Финник', N'Мало кто знает, но в каждом доме живёт домовой. Это забавное мохнатое существо, которое тайно обитает в мире людей, чтобы заботиться о доме и хранить домашний очаг. Финник — добрый и забавный домовой, но немного вредный и озорной. Он постоянно подшучивает над жильцами, поэтому ни одна семья не задерживается надолго в его владениях. Всё меняется, когда в дом въезжают новые жильцы. На них совсем не работают уловки домового и Финник внезапно знакомится с девочкой Кристиной, а в городе начинают происходить необъяснимые события. Таким не похожим друг на друга Финнику и Кристине придется объединиться, чтобы раскрыть тайну происшествий и спасти город.', 2, CAST(N'01:35:00' AS Time), N'Михаил Хрусталёв, Вероника Голубева, Ида Галич, Борис Дергачев, Андрей Лёвин, Даня Милохин, Александр Гудков, Артур Бабич, Леша Янгер, Влад Левский', N'Riki Group, Петербург', N'Денис Чернов', N'finnik.jpg')
INSERT [dbo].[Films] ([IdFilm], [NameFilm], [DescriptionFilm], [IdAgeLimit], [Duration], [Actors], [FilmsCompany], [FilmsDirectors], [PhotoPath]) VALUES (6, N'Гарри Хафт: Последний бой', N'Будоражащая история, основанная на реальных событиях о великом боксере Гарри Хафте, которого во время Второй мировой войны фашисты заставляли принимать участие в боях насмерть. Хотя ужасы Освенцима остались далеко в прошлом, память о них продолжает его проследовать. Теперь он выйдет на ринг против культового Рокки Марчиано. Но для него - это всего лишь шоу, чтобы найти свою давно потерянную любовь.', 5, CAST(N'02:20:00' AS Time), N'	Вики Крипс, Бен Фостер, Дэнни ДеВито', N'Bron Studios, New Mandate Films, Creative Wealth Media', N'Барри Левинсон', N'thesurvivor.jpg')
INSERT [dbo].[Films] ([IdFilm], [NameFilm], [DescriptionFilm], [IdAgeLimit], [Duration], [Actors], [FilmsCompany], [FilmsDirectors], [PhotoPath]) VALUES (3008, N'Тест', NULL, 4, CAST(N'02:20:00' AS Time), N'1 2', NULL, NULL, N'_nonephoto.jpg')
SET IDENTITY_INSERT [dbo].[Films] OFF
GO
SET IDENTITY_INSERT [dbo].[FilmsCountries] ON 

INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (1, 1, 99)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (2, 1, 36)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (3, 2, 45)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (4, 3, 111)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (5, 3, 42)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (6, 4, 99)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (7, 5, 88)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (8, 6, 18)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (9, 6, 42)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (10, 6, 99)
INSERT [dbo].[FilmsCountries] ([IdFilmCountry], [IdFilm], [IdCountry]) VALUES (9013, 3008, 3)
SET IDENTITY_INSERT [dbo].[FilmsCountries] OFF
GO
SET IDENTITY_INSERT [dbo].[FilmsGenres] ON 

INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (1, 1, 4)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (2, 1, 18)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (3, 2, 22)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (4, 3, 19)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (5, 4, 21)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (6, 4, 4)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (7, 5, 17)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (8, 5, 18)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (9, 6, 21)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (10, 6, 9)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (11, 6, 10)
INSERT [dbo].[FilmsGenres] ([IdFilmGenre], [IdFilm], [IdGenre]) VALUES (8026, 3008, 4)
SET IDENTITY_INSERT [dbo].[FilmsGenres] OFF
GO
SET IDENTITY_INSERT [dbo].[Formats] ON 

INSERT [dbo].[Formats] ([IdFormat], [Format]) VALUES (1, N'2D')
INSERT [dbo].[Formats] ([IdFormat], [Format]) VALUES (2, N'Atmos 2D')
INSERT [dbo].[Formats] ([IdFormat], [Format]) VALUES (3, N'3D')
SET IDENTITY_INSERT [dbo].[Formats] OFF
GO
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (1, N'Анимация', N'Особый вид киноискусства, в основе которого лежит оживление на экране различных неодушевленных объектов. Ранее более распространенным был термин мультипликация')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (2, N'Аниме', N'Японская анимация. Отличие её от мультфильмов других стран заключается в ориентированности на подростковую и взрослую аудиторию, «сериальность» и специфическую прорисовку и озвучку персонажей. Это и делает этот жанр таким популярным во всем мире. Сюжеты для аниме берутся из манги (японские комиксы).')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (3, N'Биографический', N'Фильмы этого жанра, как правило, охватывают не всю жизнь человека, а лишь наиболее важные для него годы. Биографические фильмы повествуют о жизни людей, которые оставили след в истории, например, политики, ученые или писатели.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (4, N'Боевик', N'Очень распространенный жанр кинематографа, в котором большое внимание уделяется насилию, а именно дракам, перестрелкам, погоням, спецэффектам. Сюжет боевика весьма прост: как правило, главный положительный герой борется со злом и, в итоге, ликвидирует отрицательных персонажей.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (5, N'Вестерн', N'Направление искусства в кинематографе, телевидении, литературе, живописи и др., характерное для США, может включать в себя различные жанры, например, комедию, боевик, детектив, триллер и даже фантастику. Действие в вестернах в основном происходит во второй половине 19 века на Диком Западе – будущих западных штатах США, а также в Западной Канаде и Мексике. По сюжету в центре внимания обычно жизнь и приключения полубродячего искателя, обычно ковбоя или стрелка.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (6, N'Военный', N'Исторические художественные фильмы, воссоздающие события реально происходившей войны или сражения. В центре внимания сцена главного (батального) сражения, обилие военной техники и спецэффектов. В отечественном кино военным также называют любой фильм о событиях 1941-1945 гг. вне зависимости от присутствия или отсутствия сцен сражения. ')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (7, N'Детектив', N'Фильмы данного жанра предполагают наличие загадочного происшествия (обычно преступления) и последующую его разгадку (расследование).')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (8, N'Документальный', N'Фильм, в основе которого лежат съёмки подлинных событий, лиц, культурных явлений, научных фактов и гипотез. Такие фильмы могут быть обучающими, исследовательскими, пропагандистскими, публицистическими и т.д. В Советское время чаще других использовались киножурналы, транслируемые перед киносеансами.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (9, N'Драма', N'Жанр кино, своеобразно изображающий, чаще всего, частную жизнь человека и его социальные конфликты. Особое внимание уделяется общечеловеческим противоречиям, реализующимся в поведении и поступках определенных героев.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (10, N'Исторический', N'Это фильм, отражающий реально произошедшие исторические события, но в художественной интерпретации. Подобные фильмы характеризуются эпохальной достоверностью костюмов, декораций, атмосферы того времени.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (11, N'Комедия', N'Главная задача комедии - улучшить настроение, развеселить и рассмешить зрителя. Комедии бывают разных видов: романтические, криминальные, музыкальные, пародии, трагикомедии и пр.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (12, N'Короткометражный', N'Фильм, длина которого не превышает 40-50 минут (в среднем 10-20 минут), а сюжет не ограничен никакими рамками.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (13, N'Криминал', N'Жанр фильмов, где в основе лежат хитроумные аферы, разборки бандитских группировок, смелые ограбления, остросюжетные погони и борьба с преступным миром.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (14, N'Мелодрама', N'В фильмах такого жанра в большом количестве присутствуют эмоциональные и любовные переживания героев, вызывающие широкий диапазоном чувств у зрителей. ')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (15, N'Мистика', N'Фильмы, главной нитью в которых является вера в существование потустороннего мира, сверхъестественных сил, с которыми таинственным образом связан и способен общаться человек.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (16, N'Музыкальный', N'Фильм, главные герои которого помимо диалогов исполняю песни (реже танцы) содержание которых дополняют сюжет.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (17, N'Мультфильм', N'Анимационный фильм, предназначенный в большей степени для детской аудитории. Мультики бывают рисованные, пластилиновые, кукольные, компьютерные и песочные.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (18, N'Приключения', N'Развлекательный жанр кино, где главный герой, проявляя свой ум, находчивость и смелость, выпутывается из сложных ситуаций, и увлеченно следует к своей цели, несмотря на невзгоды.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (19, N'Семейный', N'Фильм, рассчитанный на любую возрастную аудиторию, и не содержащий сцен непредназначенных для просмотра детьми.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (20, N'Спортивный', N'Жанр кино, предназначенный для неравнодушных к тому или иному виду спорта зрителей.  Герои спортивных фильмов демонстрируют силу духа, спортивный характер, стремление к победе, самоотдачу.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (21, N'Триллер', N'Фильмы данного жанра нацелены пробудить в зрителе чувство тревоги, волнения и страха. Элементы триллера встречаются во многих других жанрах кино.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (22, N'Ужасы', N'Фильмы, в которых целью является внушение зрителю чувства страха, мучительного ожидания чего-то кошмарного. Напряженная атмосфера и внезапный испуг – основные приемы жанра. В качестве главных антигероев могут выступать различные чудовища/монстры, стихия, потусторонняя сила, да и сам человек с различными девиантными отклонениями.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (23, N'Фантастика', N'Жанр кинематографа, показывающий физические, материальные, но до сих пор не обнаруженные явления. Место действия в фантастике - это, как правило, альтернативные/параллельные миры, другие планеты и Галактики. В подобных фильмах колоссальное внимание уделяют спецэффектам, для создания подходящего колорита и антуража.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (24, N'Фэнтези', N'Изначально литературный жанр, но в наши дни набирающий все большую популярность жанр кино, действие которого обычно происходит в вымышленном мире, близком к реальному Средневековью, герои которого сталкиваются со сверхъестественными явлениями и существами. Зачастую фэнтези построено на основе сказочных/мифологических сюжетов. Часто местоположение мира, в котором происходит действие относительно нашей реальности никак не оговаривается: то ли это параллельный мир, то ли другая планета, а его физические законы могут отличаться от земных.')
INSERT [dbo].[Genres] ([IdGenre], [NameGenre], [DescriptionGenre]) VALUES (25, N'Экшн', N'Это жанр фильма, в котором главный герой или главные герои оказываются втянутыми в серию событий, которые обычно включают насилие, длительные бои, физические подвиги, спасения и безумные погони. В фильмах, как правило, изображен в основном находчивый герой, который борется с невероятными препятствиями, включая опасные для жизни ситуации, опасного злодея или погоню, которая обычно заканчивается победой героя.')
GO
SET IDENTITY_INSERT [dbo].[RoleUsers] ON 

INSERT [dbo].[RoleUsers] ([IdRole], [Role]) VALUES (1, N'Администратор')
INSERT [dbo].[RoleUsers] ([IdRole], [Role]) VALUES (2, N'Сотрудник')
INSERT [dbo].[RoleUsers] ([IdRole], [Role]) VALUES (3, N'Пользователь')
SET IDENTITY_INSERT [dbo].[RoleUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Seats] ON 

INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (1, 0, 1, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (2, 1, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (3, 1, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (4, 1, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (5, 1, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (6, 1, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (7, 1, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (8, 1, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (9, 1, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (10, 1, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (11, 1, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (12, 1, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (13, 1, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (14, 1, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (15, 1, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (16, 0, 2, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (17, 16, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (18, 16, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (19, 16, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (20, 16, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (21, 16, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (22, 16, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (23, 16, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (24, 16, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (25, 16, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (26, 16, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (27, 16, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (28, 16, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (29, 16, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (30, 16, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (31, 16, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (32, 16, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (33, 16, 17, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (34, 16, 18, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (35, 0, 3, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (36, 35, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (37, 35, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (38, 35, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (39, 35, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (40, 35, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (41, 35, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (42, 35, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (43, 35, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (44, 35, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (45, 35, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (46, 35, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (47, 35, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (48, 35, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (49, 35, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (50, 35, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (51, 35, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (52, 35, 17, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (53, 35, 18, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (54, 35, 19, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (55, 35, 20, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (56, 0, 4, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (57, 56, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (58, 56, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (59, 56, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (60, 56, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (61, 56, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (62, 56, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (63, 56, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (64, 56, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (65, 56, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (66, 56, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (67, 56, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (68, 56, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (69, 56, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (70, 56, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (71, 56, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (72, 56, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (73, 56, 17, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (74, 56, 18, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (75, 56, 19, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (76, 56, 20, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (77, 0, 5, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (78, 77, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (79, 77, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (80, 77, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (81, 77, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (82, 77, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (83, 77, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (84, 77, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (85, 77, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (86, 77, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (87, 77, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (88, 77, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (89, 77, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (90, 77, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (91, 77, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (92, 77, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (93, 77, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (94, 77, 17, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (95, 77, 18, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (96, 77, 19, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (97, 77, 20, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (98, 0, 6, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (99, 98, 1, N'Место')
GO
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (100, 98, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (101, 98, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (102, 98, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (103, 98, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (104, 98, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (105, 98, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (106, 98, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (107, 98, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (108, 98, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (109, 98, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (110, 98, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (111, 98, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (112, 98, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (113, 98, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (114, 98, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (115, 98, 17, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (116, 98, 18, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (117, 98, 19, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (118, 98, 20, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (119, 0, 7, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (120, 119, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (121, 119, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (122, 119, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (123, 119, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (124, 119, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (125, 119, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (126, 119, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (127, 119, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (128, 119, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (129, 119, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (130, 119, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (131, 119, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (132, 119, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (133, 119, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (134, 119, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (135, 119, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (136, 119, 17, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (137, 119, 18, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (138, 119, 19, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (139, 119, 20, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (140, 0, 8, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (141, 140, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (142, 140, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (143, 140, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (144, 140, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (145, 140, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (146, 140, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (147, 140, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (148, 140, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (149, 140, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (150, 140, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (151, 140, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (152, 140, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (153, 140, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (154, 140, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (155, 140, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (156, 140, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (157, 0, 9, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (158, 157, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (159, 157, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (160, 157, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (161, 157, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (162, 157, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (163, 157, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (164, 157, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (165, 157, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (166, 157, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (167, 157, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (168, 157, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (169, 157, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (170, 157, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (171, 157, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (172, 157, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (173, 157, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (174, 0, 10, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (175, 174, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (176, 174, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (177, 174, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (178, 174, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (179, 174, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (180, 174, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (181, 174, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (182, 174, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (183, 174, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (184, 174, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (185, 174, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (186, 174, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (187, 174, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (188, 174, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (189, 174, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (190, 174, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (191, 0, 11, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (192, 191, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (193, 191, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (194, 191, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (195, 191, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (196, 191, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (197, 191, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (198, 191, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (199, 191, 8, N'Место')
GO
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (200, 191, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (201, 191, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (202, 191, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (203, 191, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (204, 191, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (205, 191, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (206, 191, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (207, 191, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (208, 191, 17, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (209, 191, 18, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (210, 0, 12, N'Ряд')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (211, 210, 1, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (212, 210, 2, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (213, 210, 3, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (214, 210, 4, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (215, 210, 5, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (216, 210, 6, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (217, 210, 7, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (218, 210, 8, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (219, 210, 9, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (220, 210, 10, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (221, 210, 11, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (222, 210, 12, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (223, 210, 13, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (224, 210, 14, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (225, 210, 15, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (226, 210, 16, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (227, 210, 17, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (228, 210, 18, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (229, 210, 19, N'Место')
INSERT [dbo].[Seats] ([IdSeat], [ParentId], [Number], [Decription]) VALUES (230, 210, 20, N'Место')
SET IDENTITY_INSERT [dbo].[Seats] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (1, 1, 1, CAST(N'2022-05-10' AS Date), CAST(N'10:15:00' AS Time), CAST(N'12:20:00' AS Time), 160.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (2, 1, 1, CAST(N'2022-05-11' AS Date), CAST(N'11:30:00' AS Time), CAST(N'13:35:00' AS Time), 200.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (3, 2, 1, CAST(N'2022-05-10' AS Date), CAST(N'12:30:00' AS Time), CAST(N'14:06:00' AS Time), 160.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (4, 3, 1, CAST(N'2022-05-10' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:50:00' AS Time), 200.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (5, 5, 2, CAST(N'2022-05-10' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:35:00' AS Time), 300.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (6, 5, 1, CAST(N'2022-05-11' AS Date), CAST(N'14:20:00' AS Time), CAST(N'15:55:00' AS Time), 250.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (7, 1, 1, CAST(N'2022-05-11' AS Date), CAST(N'10:20:00' AS Time), CAST(N'12:25:00' AS Time), 160.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (9, 1, 2, CAST(N'2022-05-12' AS Date), CAST(N'10:15:00' AS Time), CAST(N'12:20:00' AS Time), 190.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (10, 1, 1, CAST(N'2022-05-12' AS Date), CAST(N'11:30:00' AS Time), CAST(N'13:35:00' AS Time), 200.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (11, 1, 3, CAST(N'2022-05-13' AS Date), CAST(N'14:00:00' AS Time), CAST(N'16:05:00' AS Time), 300.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (12, 1, 1, CAST(N'2022-05-13' AS Date), CAST(N'10:00:00' AS Time), CAST(N'12:05:00' AS Time), 180.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (13, 1, 1, CAST(N'2022-05-14' AS Date), CAST(N'15:00:00' AS Time), CAST(N'17:05:00' AS Time), 250.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (14, 1, 2, CAST(N'2022-05-14' AS Date), CAST(N'20:10:00' AS Time), CAST(N'22:15:00' AS Time), 280.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (15, 1, 1, CAST(N'2022-05-14' AS Date), CAST(N'10:10:00' AS Time), CAST(N'12:15:00' AS Time), 180.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (16, 1, 1, CAST(N'2022-06-05' AS Date), CAST(N'10:15:00' AS Time), CAST(N'12:20:00' AS Time), 200.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (17, 2, 2, CAST(N'2022-06-06' AS Date), CAST(N'22:15:00' AS Time), CAST(N'23:51:00' AS Time), 200.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (18, 1, 1, CAST(N'2022-06-07' AS Date), CAST(N'10:20:00' AS Time), CAST(N'12:25:00' AS Time), 180.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (19, 1, 1, CAST(N'2022-06-06' AS Date), CAST(N'14:00:00' AS Time), CAST(N'16:05:00' AS Time), 210.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (20, 1, 1, CAST(N'2022-06-11' AS Date), CAST(N'09:40:00' AS Time), CAST(N'11:45:00' AS Time), 180.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (21, 2, 2, CAST(N'2022-06-10' AS Date), CAST(N'14:20:00' AS Time), CAST(N'15:56:00' AS Time), 200.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (1023, 1, 2, CAST(N'2022-06-08' AS Date), CAST(N'12:45:00' AS Time), CAST(N'14:50:00' AS Time), 210.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (2017, 1, 1, CAST(N'2022-06-07' AS Date), CAST(N'14:40:00' AS Time), CAST(N'16:45:00' AS Time), 250.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (2018, 1, 1, CAST(N'2022-06-07' AS Date), CAST(N'20:00:00' AS Time), CAST(N'22:05:00' AS Time), 200.0000)
INSERT [dbo].[Sessions] ([IdSession], [IdFilm], [IdFormat], [DateSession], [StartTime], [EndTime], [CostTicket]) VALUES (2019, 3008, 1, CAST(N'2022-06-10' AS Date), CAST(N'12:30:00' AS Time), CAST(N'14:50:00' AS Time), 170.0000)
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1, 16, 108, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2, 16, 109, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (3, 16, 110, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (4, 16, 70, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (5, 16, 71, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (6, 16, 180, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (7, 16, 148, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (8, 16, 134, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (9, 16, 133, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (10, 16, 132, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (11, 16, 131, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (12, 16, 29, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (13, 16, 28, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (14, 16, 27, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (15, 16, 61, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (16, 16, 62, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (17, 16, 63, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (18, 16, 64, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (19, 16, 65, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (20, 16, 66, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (21, 16, 221, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (22, 16, 222, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (23, 16, 168, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (24, 16, 169, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (25, 16, 104, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (26, 16, 105, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (27, 16, 190, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (28, 17, 221, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (29, 17, 222, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (30, 17, 151, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (31, 17, 147, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (32, 17, 146, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (33, 18, 106, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (34, 18, 107, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (35, 18, 108, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (36, 19, 165, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (37, 19, 166, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (38, 19, 167, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (39, 19, 84, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (40, 19, 85, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (41, 19, 126, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (42, 19, 127, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (43, 19, 132, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (44, 19, 133, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (45, 19, 71, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (46, 19, 220, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (47, 19, 219, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (57, 17, 91, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (58, 17, 92, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1057, 16, 218, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1058, 16, 217, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1061, 17, 161, 2004)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1062, 17, 162, 2004)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1063, 17, 163, 2004)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1064, 16, 142, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1065, 17, 86, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1066, 17, 87, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1067, 18, 67, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1068, 18, 68, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1069, 17, 129, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1070, 17, 130, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1071, 18, 165, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1072, 18, 166, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (1073, 18, 167, 2)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2057, 19, 66, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2058, 19, 67, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2059, 19, 68, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2060, 19, 66, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2061, 19, 67, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2062, 19, 68, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2063, 19, 66, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2064, 19, 67, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2065, 19, 68, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2066, 19, 178, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2067, 19, 179, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2068, 19, 180, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2069, 19, 147, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2070, 19, 148, 1)
INSERT [dbo].[Tickets] ([IdTicket], [IdSession], [IdSeat], [IdUser]) VALUES (2071, 19, 146, 1)
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([IdUser], [LastName], [FirstName], [Patronymic], [Email], [Login], [Password], [Phone], [IdRole]) VALUES (1, N'Админ', N'Админ', NULL, N'admin@mail.ru', N'Admin', N'admin123', NULL, 1)
INSERT [dbo].[Users] ([IdUser], [LastName], [FirstName], [Patronymic], [Email], [Login], [Password], [Phone], [IdRole]) VALUES (2, N'qw', N'wq', NULL, N'qw@mail.ru', N'qw', N'qw', NULL, 3)
INSERT [dbo].[Users] ([IdUser], [LastName], [FirstName], [Patronymic], [Email], [Login], [Password], [Phone], [IdRole]) VALUES (2003, N'Иванов', N'Иван', N'Иванович', N'ivanov@mail.ru', N'ivanov', N'qwerty', NULL, 3)
INSERT [dbo].[Users] ([IdUser], [LastName], [FirstName], [Patronymic], [Email], [Login], [Password], [Phone], [IdRole]) VALUES (2004, N'Смирнова', N'Лидия', N'Ивановна', N'smirniva97@mail.ru', N'Smirn97', N'qwerty', NULL, 3)
INSERT [dbo].[Users] ([IdUser], [LastName], [FirstName], [Patronymic], [Email], [Login], [Password], [Phone], [IdRole]) VALUES (3003, N'Кычакова', N'Екатерина', N'Алексеевна', N'katya.10.04@mail.ru', N'timveur', N'pass104', NULL, 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Films]  WITH CHECK ADD  CONSTRAINT [FK_Films_AgeLimits] FOREIGN KEY([IdAgeLimit])
REFERENCES [dbo].[AgeLimits] ([IdAgeLimit])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Films] CHECK CONSTRAINT [FK_Films_AgeLimits]
GO
ALTER TABLE [dbo].[FilmsCountries]  WITH CHECK ADD  CONSTRAINT [FK_FilmsCountries_Countries] FOREIGN KEY([IdCountry])
REFERENCES [dbo].[Countries] ([IdCountry])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmsCountries] CHECK CONSTRAINT [FK_FilmsCountries_Countries]
GO
ALTER TABLE [dbo].[FilmsCountries]  WITH CHECK ADD  CONSTRAINT [FK_FilmsCountries_Films] FOREIGN KEY([IdFilm])
REFERENCES [dbo].[Films] ([IdFilm])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmsCountries] CHECK CONSTRAINT [FK_FilmsCountries_Films]
GO
ALTER TABLE [dbo].[FilmsGenres]  WITH CHECK ADD  CONSTRAINT [FK_FilmsGenres_Films] FOREIGN KEY([IdFilm])
REFERENCES [dbo].[Films] ([IdFilm])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmsGenres] CHECK CONSTRAINT [FK_FilmsGenres_Films]
GO
ALTER TABLE [dbo].[FilmsGenres]  WITH CHECK ADD  CONSTRAINT [FK_FilmsGenres_Genres] FOREIGN KEY([IdGenre])
REFERENCES [dbo].[Genres] ([IdGenre])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmsGenres] CHECK CONSTRAINT [FK_FilmsGenres_Genres]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Films] FOREIGN KEY([IdFilm])
REFERENCES [dbo].[Films] ([IdFilm])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Films]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Formats] FOREIGN KEY([IdFormat])
REFERENCES [dbo].[Formats] ([IdFormat])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Formats]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Seats] FOREIGN KEY([IdSeat])
REFERENCES [dbo].[Seats] ([IdSeat])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Seats]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Sessions] FOREIGN KEY([IdSession])
REFERENCES [dbo].[Sessions] ([IdSession])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Sessions]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_RoleUsers] FOREIGN KEY([IdRole])
REFERENCES [dbo].[RoleUsers] ([IdRole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_RoleUsers]
GO
