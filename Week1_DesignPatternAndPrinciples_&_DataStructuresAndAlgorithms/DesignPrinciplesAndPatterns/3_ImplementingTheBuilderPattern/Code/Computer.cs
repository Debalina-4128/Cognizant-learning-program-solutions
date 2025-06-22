using System;
public class Computer
{
    public string CPU;
    public string RAM;
    public string Storage;


    private Computer(Builder builder)
    {
        CPU = builder.CPU;
        RAM = builder.RAM;
        Storage = builder.Storage;
    }

    public class Builder
    {
        public string CPU;
        public string RAM;
        public string Storage;

        public Builder SetCPU(String cpu)
        {
            this.CPU = cpu;
            return this;
        }

        public Builder SetRAM(string ram)
        {
            this.RAM = ram;
            return this;
        }

        public Builder SetStorage(string storage)
        {
            this.Storage = storage;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }
}