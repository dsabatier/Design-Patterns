using System;

/// <summary>
/// Decorators allow for attaching additional responsibilities to an object at runtime.  Alternative to subclassing.
/// </summary>
namespace Design_Patterns.Decorator
{
    public class Scope : GunDecorator
    {
        public Scope(GunChassis gun) : base(gun)
        {
            
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

    // does nothing to the gun performance
    public class Paint : GunDecorator
    {
        public Paint(GunChassis gun) : base(gun)
        {

        }

        public override int GetAccuracy()
        {
            return _gun.GetAccuracy();
        }

        public override int GetRateOfFire()
        {
            return _gun.GetRateOfFire();
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
            _gun = gun;
        }
    }
}
