using System;
using System.Text;

class TuringMachine
{
    public static void Main(string[] args)
    {
        string input = "*101*";
        int cell = input.Length - 1;
        StringBuilder tape = new StringBuilder();
        tape.Append(input);
        string state = "START";
        char read;
        Console.WriteLine(input + " " + state);

        do
        {
            read = tape[cell];

            if (state == "START" && read == '*')
            {
                tape[cell] = '*';
                cell--;
                state = "ADD";
            }
            else if (state == "ADD" && read == '0')
            {
                tape[cell] = '1';
                cell++;
                state = "RETURN";
            }
            else if (state == "ADD" && read == '1')
            {
                tape[cell] = '0';
                cell--;
                state = "CARRY";
            }
            else if (state == "ADD" && read == '*')
            {
                cell++;
                state = "HALT";
            }
            else if (state == "CARRY" && read == '0')
            {
                tape[cell] = '1';
                cell++;
                state = "RETURN";
            }
            else if (state == "CARRY" && read == '1')
            {
                tape[cell] = '0';
                cell--;
                state = "CARRY";
            }
            else if (state == "CARRY" && read == '*')
            {
                tape.Insert(0, '*');
                cell = 0;
                state = "OVERFLOW";
            }
            else if (state == "OVERFLOW" && read == '*')
            {
                cell++;
                state = "RETURN";
            }
            else if (state == "RETURN" && read == '0')
            {
                cell++;
                state = "RETURN";
            }
            else if (state == "RETURN" && read == '1')
            {
                cell++;
                state = "RETURN";
            }
            else if (state == "RETURN" && read == '*')
            {
                state = "HALT";
            }

            Console.WriteLine(tape + " " + state);
        } while (state != "HALT");
    }
}