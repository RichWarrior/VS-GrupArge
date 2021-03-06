USE [School]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 28.08.2018 08:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[classroom] [varchar](50) NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam_Date]    Script Date: 28.08.2018 08:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam_Date](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_id] [int] NULL,
	[exam_date] [datetime] NULL,
 CONSTRAINT [PK_Exam_Date] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 28.08.2018 08:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 28.08.2018 08:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name_surname] [varchar](50) NULL,
	[number] [varchar](50) NULL,
	[classroom] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Teacher]    Script Date: 28.08.2018 08:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NULL,
	[teacher_id] [int] NULL,
 CONSTRAINT [PK_Student_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 28.08.2018 08:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lesson_id] [int] NULL,
	[name_surname] [varchar](50) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Exam_Date]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Date_Teacher1] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exam_Date] CHECK CONSTRAINT [FK_Exam_Date_Teacher1]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([classroom])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO
ALTER TABLE [dbo].[Student_Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Student_Teacher_Student1] FOREIGN KEY([student_id])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[Student_Teacher] CHECK CONSTRAINT [FK_Student_Teacher_Student1]
GO
ALTER TABLE [dbo].[Student_Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Student_Teacher_Teacher1] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Student_Teacher] CHECK CONSTRAINT [FK_Student_Teacher_Teacher1]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Lesson1] FOREIGN KEY([lesson_id])
REFERENCES [dbo].[Lesson] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Lesson1]
GO
