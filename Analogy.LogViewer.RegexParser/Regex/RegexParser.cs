using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces.DataTypes;

namespace Analogy.LogViewer.RegexParser
{
    public class RegexParser
    {
        private AnalogyLogMessage? _current;
        private RegexPattern _matchedPattern;
        private readonly List<IAnalogyLogMessage> _messages = new List<IAnalogyLogMessage>();
        private List<RegexPattern> _logPatterns;
        private readonly bool updateUIAfterEachParsedLine;
        private IAnalogyLogger Logger { get; }


        public static IEnumerable<string> RegexMembers { get; }
        private static Dictionary<string, AnalogyLogMessagePropertyName> regexMapper;

        static RegexParser()
        {
            var names = Enum.GetNames(typeof(AnalogyLogMessagePropertyName));
            RegexMembers = names;
            regexMapper = new Dictionary<string, AnalogyLogMessagePropertyName>(names.Length);
            foreach (var name in names)
            {
                var enumValue = (AnalogyLogMessagePropertyName)Enum.Parse(typeof(AnalogyLogMessagePropertyName), name);
                regexMapper.Add(name, enumValue);
            }
        }

        public RegexParser(List<RegexPattern> logPatterns, bool updateUIAfterEachLine, IAnalogyLogger logger)
        {
            _logPatterns = logPatterns;
            Logger = logger;
            updateUIAfterEachParsedLine = updateUIAfterEachLine;

        }

        public void SetRegexPatterns(List<RegexPattern> logPatterns) => _logPatterns = logPatterns;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryParse(string line, RegexPattern regex, out AnalogyLogMessage? message)
        {
            try
            {
                Match match = Regex.Match(line, regex.Pattern,
                    RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
                if (match.Success)
                {
                    var properties = new List<(AnalogyLogMessagePropertyName, string)>();
                    foreach (var regexMember in regexMapper)
                    {
                        string value = match.Groups[regexMember.Key].Success
                            ? match.Groups[regexMember.Key].Value
                            : string.Empty;
                        properties.Add((regexMember.Value, value));
                    }
                    message = AnalogyLogMessage.Parse(properties);
                    return true;
                }

                message = null;
                return false;
            }
            catch (Exception e)
            {
                string error = $"Error parsing line: {e.Message}";
                Logger?.LogException(error, e, nameof(RegexParser));
                message = new AnalogyLogMessage(error, AnalogyLogLevel.Error, AnalogyLogClass.General,
                    nameof(RegexParser));
                return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckRegex(string line, RegexPattern regex, out AnalogyLogMessage message)
        {
            try
            {
                Match match = Regex.Match(line, regex.Pattern,
                    RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
                if (match.Success)
                {
                    var m = new AnalogyLogMessage();
                    foreach (var regexMember in regexMapper)
                    {
                        string value = match.Groups[regexMember.Key].Success
                            ? match.Groups[regexMember.Key].Value
                            : string.Empty;
                        switch (regexMember.Value)
                        {
                            case AnalogyLogMessagePropertyName.Date:
                                if (!string.IsNullOrEmpty(value) &&
                                    DateTime.TryParseExact(value, regex.DateTimeFormat, CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out var date))
                                {
                                    m.Date = date;
                                }

                                continue;
                            case AnalogyLogMessagePropertyName.Id:
                                if (!string.IsNullOrEmpty(value) &&
                                    Guid.TryParseExact(value, regex.GuidFormat, out var guidValue))
                                {
                                    m.Id = guidValue;
                                }

                                continue;
                            case AnalogyLogMessagePropertyName.Text:
                                m.Text = value;
                                continue;
                            case AnalogyLogMessagePropertyName.Source:
                                m.Source = value;
                                break;
                            case AnalogyLogMessagePropertyName.Module:
                                m.Module = value;
                                continue;
                            case AnalogyLogMessagePropertyName.MethodName:
                                m.MethodName = value;
                                continue;
                            case AnalogyLogMessagePropertyName.MachineName:
                                m.MachineName = value;
                                continue;
                            case AnalogyLogMessagePropertyName.FileName:
                                m.FileName = value;
                                continue;
                            case AnalogyLogMessagePropertyName.User:
                                m.User = value;
                                continue;
                            case AnalogyLogMessagePropertyName.LineNumber:
                                if (!string.IsNullOrEmpty(value) &&
                                    int.TryParse(value, out var lineNum))
                                {
                                    m.LineNumber = lineNum;
                                }

                                continue;
                            case AnalogyLogMessagePropertyName.ProcessId:
                                if (!string.IsNullOrEmpty(value) &&
                                    int.TryParse(value, out var processNum))
                                {
                                    m.ProcessId = processNum;
                                }

                                continue;
                            case AnalogyLogMessagePropertyName.ThreadId:
                                if (!string.IsNullOrEmpty(value) &&
                                    int.TryParse(value, out var threadNum))
                                {
                                    m.ThreadId = threadNum;
                                }

                                continue;
                            case AnalogyLogMessagePropertyName.Level:
                                switch (value)
                                {
                                    case "OFF":
                                        m.Level = AnalogyLogLevel.None;
                                        break;
                                    case "TRACE":
                                        m.Level = AnalogyLogLevel.Trace;
                                        break;
                                    case "DEBUG":
                                        m.Level = AnalogyLogLevel.Debug;
                                        break;
                                    case "INFO":
                                        m.Level = AnalogyLogLevel.Information;
                                        break;
                                    case "WARN":
                                        m.Level = AnalogyLogLevel.Warning;
                                        break;
                                    case "ERROR":
                                        m.Level = AnalogyLogLevel.Error;
                                        break;
                                    case "FATAL":
                                        m.Level = AnalogyLogLevel.Critical;
                                        break;
                                    default:
                                        m.Level = AnalogyLogLevel.Unknown;
                                        break;
                                }

                                continue;
                            case AnalogyLogMessagePropertyName.Class:
                                if (string.IsNullOrEmpty(value))
                                {
                                    m.Class = AnalogyLogClass.General;
                                }
                                else
                                {
                                    m.Class = Enum.TryParse(value, true, out AnalogyLogClass cls) &&
                                              Enum.IsDefined(typeof(AnalogyLogClass), cls)
                                        ? cls
                                        : AnalogyLogClass.General;

                                }
                                continue;
                            case AnalogyLogMessagePropertyName.RawText:
                                m.RawText = value;
                                break;
                            case AnalogyLogMessagePropertyName.RawTextType:
                                m.RawTextType = Enum.TryParse(value, true, out AnalogyRowTextType rt) &&
                                              Enum.IsDefined(typeof(AnalogyLogClass), rt)
                                        ? rt
                                        : AnalogyRowTextType.Unknown;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    message = m;
                    return true;
                }

                message = null;
                return false;
            }
            catch (Exception e)
            {
                string error = $"Error parsing line: {e.Message}";
                message = new AnalogyLogMessage(error, AnalogyLogLevel.Error, AnalogyLogClass.General,
                    nameof(RegexParser));
                return false;
            }
        }

        public async Task<List<IAnalogyLogMessage>> ParseLog(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {

            _messages.Clear();
            long count = 0;
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                bool TryParseInternal(string line, out AnalogyLogMessage msg)
                {
                    if (_matchedPattern != null)
                    {
                        if (TryParse(line, _matchedPattern, out var m1))
                        {
                            msg = m1;
                            return true;
                        }
                        msg = null;
                        return false;
                    }

                    foreach (var logPattern in _logPatterns)
                    {
                        if (TryParse(line, logPattern, out var m2))
                        {
                            msg = m2;
                            _matchedPattern = logPattern;
                            return true;

                        }
                    }

                    msg = null;
                    return false;

                }
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line = string.Empty;
                    string currentLine;
                    while ((currentLine = await streamReader.ReadLineAsync().ConfigureAwait(false)) != null)
                    {
                        line += currentLine;
                        if (TryParseInternal(line, out var entry))
                        {
                            line = string.Empty;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(line))
                            {
                                line = currentLine;
                            }

                            continue;
                        }

                        if (entry != null)
                        {
                            if (updateUIAfterEachParsedLine)
                            {
                                messagesHandler.AppendMessage(entry, fileName);
                                count++;
                                messagesHandler.ReportFileReadProgress(new AnalogyFileReadProgress(AnalogyFileReadProgressType.Incremental, 1, count, count));
                            }

                            _current = entry;
                            _messages.Add(_current);
                        }
                        else
                        {
                            if (_current == null)
                            {
                                _current = new AnalogyLogMessage { Text = line };
                            }
                            else
                            {
                                _current.Text += Environment.NewLine + line;
                            }
                        }

                        if (token.IsCancellationRequested)
                        {
                            messagesHandler.AppendMessages(_messages, fileName);
                            return _messages;
                        }
                    }
                }
            }

            if (!updateUIAfterEachParsedLine) //update only at the end
            {
                messagesHandler.AppendMessages(_messages, fileName);
            }

            return _messages;
        }

    }
}
