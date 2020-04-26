using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using static System.Console;

namespace ContactWriter
{
    class ContactConsoleWriter
    {

        private readonly Contact _contact;
        private ConsoleColor _color;

        public ContactConsoleWriter(Contact contact)
        {

            _contact = contact;
        }


        [Obsolete("This will be removed in version 2")]
        public void Write()
        {

            UseDefaultColor();
            WriteFirstName();
            WriteAge();

        }
        private void WriteFirstName()
        {

            PropertyInfo firstNameProperty = typeof(Contact).GetProperty(nameof(Contact.FirstName));

            DisplayAttribute firstNameDisplayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(firstNameProperty, typeof(DisplayAttribute));

            IndentAttribute[] indentAtrributes = (IndentAttribute[])Attribute.GetCustomAttributes(firstNameProperty, typeof(IndentAttribute));

            PreserveForegroundColor();

            StringBuilder sb = new StringBuilder();

            if (indentAtrributes != null)
            {
                foreach (var a in indentAtrributes)
                {
                    sb.Append(new string(' ', 4));
                }
            }

            if (firstNameDisplayAttribute != null)
            {
                ForegroundColor = firstNameDisplayAttribute.Color;
                sb.Append(firstNameDisplayAttribute.Label);
            }
            if (_contact.FirstName != null)
            {
                sb.Append(_contact.FirstName);
            }

            WriteLine(sb);
            RestoreForegroundColor();
        }

        private void WriteAge()
        {

            OutputDebugInfo();
            WriteLine(_contact.AgeInYears);

        }

        [Conditional("DEBUG")]
        public void OutputDebugInfo()
        {
            WriteLine("***DEBUG MODE***");
        }

        private void PreserveForegroundColor()
        {
            _color = ForegroundColor;
        }
        private void RestoreForegroundColor()
        {
            ForegroundColor = _color;
        }

        private void UseDefaultColor()
        {
            DefaultColorAttribute defaultColorAttribute = (DefaultColorAttribute)Attribute.GetCustomAttribute(typeof(Contact), typeof(DefaultColorAttribute));

            if (defaultColorAttribute != null)
            {
                ForegroundColor = defaultColorAttribute.Color;
            }

        }

    }
}