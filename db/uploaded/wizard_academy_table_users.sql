
-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `users`
--

CREATE TABLE `users` (
  `id` int(4) NOT NULL,
  `name` varchar(40) NOT NULL,
  `pw` varchar(40) NOT NULL,
  `class` int(1) NOT NULL,
  `lvl` int(3) NOT NULL,
  `xp` int(10) NOT NULL,
  `max_xp` int(10) NOT NULL,
  `m_xp` int(10) NOT NULL,
  `e_xp` int(10) NOT NULL,
  `lifes` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `users`
--

INSERT INTO `users` (`id`, `name`, `pw`, `class`, `lvl`, `xp`, `max_xp`, `m_xp`, `e_xp`, `lifes`) VALUES
(1, 'test', 'test', 6, 4, 10, 4000, 1990, 1020, 197),
(2, 'paul', 'luap', 9, 5, 1200, 1500, 1000, 200, 7);
