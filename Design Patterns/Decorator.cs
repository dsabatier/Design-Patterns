using System;

namespace Design_Patterns.Decorator
{
    public class Scope : GunDecorator
    {
        public Scope(GunChassis gun) : base(gun)
        {
            _gun = gun;
        }

        public override int GetAccuracy()
        {
            return _gun.GetAccuracy() + 5;
        }

        public override int GetRateOfFire()
        {
            return _gun.GetRateOfFire();
        }
    }

    public class Automatic : GunDecorator
    {
        public Automatic(GunChassis gun) : base(gun)
        {
            _gun = gun;
        }

        public override int GetAccuracy()
        {
            return _gun.GetAccuracy();
        }

        public override int GetRateOfFire()
        {
            return _gun.GetRateOfFire() + 5;
        }
    }

    public class HeavyGunChassis : GunChassis
    {
        public override int GetAccuracy()
        {
            return 1;
        }

        public override int GetRateOfFire()
        {
            return 5;
        }
    }

    public class LightGunChassis : GunChassis
    {
        public override int GetAccuracy()
        {
            return 5;
        }

        public override int GetRateOfFire()
        {
            return 1;
        }
    }

    public abstract class GunChassis
    {
        public abstract int GetRateOfFire();

        public abstract int GetAccuracy();
    }

    public abstract class GunDecorator : GunChassis
    {
        protected GunChassis _gun;

        public GunDecorator(GunChassis gun)
        {
            Console.WriteLine("decorating..");
            _gun = gun;
        }
    }
}
