using System;
using System.Reflection;

namespace RendleLabs.InfluxDB.DiagnosticSourceListener.TypedFormatters
{
    internal class SingleFieldFormatter : TypedFormatter<float>, IFormatter
    {
        public SingleFieldFormatter(PropertyInfo property) : base(property)
        {
        }

        public bool TryWrite(object obj, Span<byte> span, bool commaPrefix, out int bytesWritten)
        {
            return FieldHelpers.Write(Name.AsSpan(), Getter(obj), commaPrefix, span, out bytesWritten);
        }
    }
}