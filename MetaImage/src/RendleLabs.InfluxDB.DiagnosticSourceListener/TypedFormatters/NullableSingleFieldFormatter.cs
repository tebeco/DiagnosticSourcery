using System;
using System.Reflection;

namespace RendleLabs.InfluxDB.DiagnosticSourceListener.TypedFormatters
{
    internal class NullableSingleFieldFormatter : TypedFormatter<float?>, IFormatter
    {
        public NullableSingleFieldFormatter(PropertyInfo property) : base(property)
        {
        }

        public bool TryWrite(object obj, Span<byte> span, bool commaPrefix, out int bytesWritten)
        {
            return FieldHelpers.Write(Name.AsSpan(), Getter(obj).GetValueOrDefault(), commaPrefix, span, out bytesWritten);
        }
    }
}