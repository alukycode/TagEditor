/*
     заимплементить два способа:
     1) точный, по словарю, в котором содержится:
        - сайт
        - правило генерации урла
        - индикатор начала текста
        - индикатор конца текст (необязательно)
        http://www.azlyrics.com/lyrics/entershikari/mothership.html
        http://www.plyrics.com/lyrics/entershikari/mothership.html
        http://www.lyricsmode.com/lyrics/e/enter_shikari/mothership_lyrics.html
        http://www.metrolyrics.com/mothership-lyrics-enter-shikari.html
        http://www.lyricsmania.com/mothership_lyrics_enter_shikari.html
        не помешает чекнуть siteName в полученной лирике, возможно вставляется копирайт
    
     2) неточный, берется сайт и в нём находится название песни и исполнителя, и рядом с этим находится большой блок с текстом
    
     3) на амальгаму сгенерять ссылочку и чекнуть, есть ли песня в базе, если да, то отдать ссылочку
        http://www.amalgama-lab.com/songs/e/enter_shikari/mothership.html
*/

namespace Helpers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    using HtmlAgilityPack;

    using Shared;

    public static class LyricsHelper
    {
        private static string _lastQuery = string.Empty;
        private static int _lastIndex = 0;

        public static LyricsInfo GetLyrics(string artist, string title)
        {
            var searchQuery = artist + " " + title + " " + "lyrics";
            var lyricsUrls = GoogleHelper.GetSearchUrls(searchQuery);

            var index = 0;
            if (_lastQuery == searchQuery)
            {
                _lastIndex++;
                if (_lastIndex >= lyricsUrls.Count)
                    _lastIndex = 0;
                index = _lastIndex;
            }
            else
            {
                _lastQuery = searchQuery;
                _lastIndex = 0;
            }

            var url = lyricsUrls[index];

            var lyricsHtml = WebRequestHelper.DownloadSiteHtml(url);

            var lyrics = GetLyricsFromHtml(lyricsHtml);

            var lyricsInfo = new LyricsInfo
            {
                Url = url,
                Lyrics = lyrics,
                Index = index,
                TotalCount = lyricsUrls.Count
            };

            return lyricsInfo;
        }

        private static string GetLyricsFromHtml(string lyricsHtml)
        {
            if (lyricsHtml == String.Empty) return string.Empty;

            // 1. extract all leaf div nodes from html document
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(lyricsHtml);
            var documentNode = htmlDocument.DocumentNode;
            var allDivs = documentNode.Descendants().Where(x => x.Name == "div");
            var divsWithoutChildDivs = allDivs.Where(x => x.Descendants().All(y => y.Name != "div"));

            // 2. find the longest text
            var longestText = string.Empty;
            var longestTextWithoutSpaces = string.Empty;
            foreach (var div in divsWithoutChildDivs)
            {
                var innerHtml = div.InnerHtml;
                innerHtml = innerHtml.Replace("<i>", string.Empty);
                innerHtml = innerHtml.Replace("</i>", string.Empty);
                var textWithoutTags = Regex.Replace(innerHtml, @"<[^>]+>", Environment.NewLine);
                var textWithoutSpaces = Regex.Replace(textWithoutTags, @"\s+", string.Empty);
                if (textWithoutSpaces.Length > longestTextWithoutSpaces.Length)
                {
                    longestText = textWithoutTags;
                    longestTextWithoutSpaces = textWithoutSpaces;
                }
            }

            // 3. remove empty lines/spaces
            var lines = longestText
                .Split(new [] { Environment.NewLine }, StringSplitOptions.None)
                .Select(x => x.Trim())
                .ToList();

            // 3.1 trime empty lines at the start/end
            while (lines.First() == string.Empty)
            {
                lines.RemoveAt(0);
            }
            while (lines.Last() == string.Empty)
            {
                lines.RemoveAt(lines.Count - 1);
            }

            // 3.2 find minimum count of consecutive empty lines
            int minEmptyLinesCount = int.MaxValue;
            int emptyLinesCount = 0;
            foreach (var line in lines.Skip(1))
            {
                if (line == string.Empty)
                {
                    emptyLinesCount++;
                    continue;
                }
                
                if (minEmptyLinesCount > emptyLinesCount)
                {
                    minEmptyLinesCount = emptyLinesCount;
                }

                emptyLinesCount = 0;
            }

            // 3.3 remove empty lines if emptyLinesCount = minEmptyLinesCount
            //     add one new line if emptyLinesCount > minEmptyLinesCount
            emptyLinesCount = 0;
            string result = string.Empty;
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    emptyLinesCount++;
                    continue;
                }

                if (emptyLinesCount > minEmptyLinesCount)
                {
                    result += Environment.NewLine;
                    emptyLinesCount = 0;
                }

                result += (line + Environment.NewLine);
            }

            return result;
        }

        private static bool IsRussian(string text)
        {
            return Regex.IsMatch(text, "[а-яА-ЯеЁ]");
        }

        private static string RemoveTags(string text)
        {
            return Regex.Replace(text, @"<[^>]+>", string.Empty);
        }
    }
}
