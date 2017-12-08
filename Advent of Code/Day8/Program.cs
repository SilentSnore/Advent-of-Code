using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string hugeText = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\in.txt");
            //string hugeText = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\example.txt");
            string[] lines = hugeText.Split('\n');
            List<Data> registers = new List<Data>();
            foreach (string line in lines)
            {
                string[] info = line.Split(' ');
                string name = info[0].Trim();
                Data reg = new Data();
                reg.Name = name;
                reg.Value = 0;
                if(!registers.Contains(reg))
                    registers.Add(reg);
            }

            int totalMax = Int32.MinValue;
            foreach (string line in lines)
            {
                string[] info = line.Split(' ');
                string name = info[0].Trim();
                string op = info[1].Trim();
                int value = Int32.Parse(info[2].Trim());
                string conditionRegister = info[4].Trim();
                string condition = info[5].Trim();
                int conditionValue = Int32.Parse(info[6].Trim());

                if (!CheckCondition(conditionRegister, condition, conditionValue, registers))
                    continue;
                if (op.Equals("dec"))
                {
                    registers[GetRegisterIndex(name, registers)].Value -= value;
                }
                else
                {
                    registers[GetRegisterIndex(name, registers)].Value += value;
                }

                foreach (Data register in registers)
                {
                    if (register.Value > totalMax)
                        totalMax = register.Value;
                }
            }

            int max = Int32.MinValue;
            foreach (Data register in registers)
            {
                if (register.Value > max)
                    max = register.Value;
            }
            Console.WriteLine(max);
            Console.WriteLine(totalMax);

            Console.ReadKey();
        }

        private static int GetRegisterIndex(string registerName, List<Data> registers)
        {
            return registers.FindIndex(reg => reg.Name.Equals(registerName));
        }

        private static bool CheckCondition(string conditionRegister, string condition, int conditionValue, List<Data> registers)
        {
            switch (condition)
            {
                case "<":
                    return registers[GetRegisterIndex(conditionRegister, registers)].Value < conditionValue;
                case ">":
                    return registers[GetRegisterIndex(conditionRegister, registers)].Value > conditionValue;
                case "==":
                    return registers[GetRegisterIndex(conditionRegister, registers)].Value == conditionValue;
                case "<=":
                    return registers[GetRegisterIndex(conditionRegister, registers)].Value <= conditionValue;
                case ">=":
                    return registers[GetRegisterIndex(conditionRegister, registers)].Value >= conditionValue;
                case "!=":
                    return registers[GetRegisterIndex(conditionRegister, registers)].Value != conditionValue;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    class Data
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Data dataObj))
                return false;
            return dataObj.Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
