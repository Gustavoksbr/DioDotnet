-- Desafio 1
Select Nome,Ano from Filmes;

-- Desafio 2
Select Nome,Ano from Filmes Order by Ano;

-- Desafio 3

Select Nome,Ano,Duracao from Filmes WHERE Nome = 'De Volta para o Futuro';

-- Desafio 4

SELECT * FROM Filmes WHERE ANO =1997;

-- Desafio 5

SELECT * FROM Filmes Where Ano > 2000;

-- Desafio 6

SELECT * FROM Filmes WHERE 100 < Duracao and Duracao < 150 ORDER BY Duracao;

-- Desafio 7

SELECT Ano, COUNT(*) as Quantidade
FROM Filmes
GROUP BY Ano
ORDER BY COUNT(*) DESC;

-- Desafio 8

SELECT PrimeiroNome, UltimoNome from Atores WHERE genero = 'M';

-- Desafio 9

SELECT PrimeiroNome, UltimoNome from Atores WHERE genero = 'F' Order By PrimeiroNome;

-- Desafio 10

SELECT f.Nome, g.Genero from Generos g
                                 INNER JOIN FilmesGenero fg ON fg.IdGenero = g.id
                                 INNER JOIN Filmes f ON f.id = fg.IdFilme;

-- Desafio 11

SELECT f.Nome, g.Genero from Generos g
                                 INNER JOIN FilmesGenero fg ON fg.IdGenero = g.id
                                 INNER JOIN Filmes f ON f.id = fg.IdFilme
WHERE Genero = 'Mistério';

-- Desafio 12

SELECT f.Nome, a.PrimeiroNome, a.UltimoNome, ef.Papel from ElencoFilme ef
                                                               INNER JOIN Filmes f ON ef.IdFilme = f.id
                                                               INNER JOIN Atores a ON a.Id = ef.IdAtor;