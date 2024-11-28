namespace CourseWork;

public class ThermodynamicProperties
{
    private static Dictionary<double, ThermodynamicData> thermodynamicPropertiesH2 =
        new Dictionary<double, ThermodynamicData>
        {
            { 100, new ThermodynamicData { Cp = 28.155, H = 2.999, S = 100.616, Phi = 70.624 } },
            { 200, new ThermodynamicData { Cp = 27.447, H = 5.693, S = 119.301, Phi = 90.836 } },
            { 298.15, new ThermodynamicData { Cp = 28.836, H = 8.468, S = 130.570, Phi = 102.169 } },
            { 300, new ThermodynamicData { Cp = 28.849, H = 8.521, S = 130.747, Phi = 102.345 } },
            { 400, new ThermodynamicData { Cp = 29.181, H = 11.426, S = 139.104, Phi = 110.538 } },
            { 500, new ThermodynamicData { Cp = 29.260, H = 14.349, S = 145.626, Phi = 116.927 } },
            { 600, new ThermodynamicData { Cp = 29.327, H = 17.278, S = 150.966, Phi = 122.169 } },
            { 700, new ThermodynamicData { Cp = 29.420, H = 20.216, S = 155.494, Phi = 126.614 } },
            { 800, new ThermodynamicData { Cp = 29.643, H = 23.161, S = 159.402, Phi = 130.476 } },
            { 900, new ThermodynamicData { Cp = 29.880, H = 26.113, S = 162.940, Phi = 133.892 } },
            { 1000, new ThermodynamicData { Cp = 30.204, H = 29.074, S = 166.104, Phi = 136.957 } },
            { 1100, new ThermodynamicData { Cp = 30.580, H = 32.042, S = 169.000, Phi = 139.740 } },
            { 1200, new ThermodynamicData { Cp = 30.991, H = 35.018, S = 171.678, Phi = 142.292 } },
            { 1300, new ThermodynamicData { Cp = 31.422, H = 38.002, S = 174.176, Phi = 144.656 } },
            { 1400, new ThermodynamicData { Cp = 31.860, H = 40.994, S = 176.520, Phi = 146.870 } },
            { 1500, new ThermodynamicData { Cp = 32.236, H = 43.992, S = 178.733, Phi = 148.967 } },
            { 1600, new ThermodynamicData { Cp = 32.794, H = 47.008, S = 180.832, Phi = 150.827 } },
            { 1700, new ThermodynamicData { Cp = 32.729, H = 50.031, S = 182.822, Phi = 152.553 } },
            { 1800, new ThermodynamicData { Cp = 33.396, H = 53.060, S = 184.735, Phi = 154.167 } },
            { 1900, new ThermodynamicData { Cp = 33.746, H = 56.096, S = 186.576, Phi = 155.681 } },
            { 2000, new ThermodynamicData { Cp = 34.277, H = 61.417, S = 188.306, Phi = 157.597 } },
            { 2100, new ThermodynamicData { Cp = 34.622, H = 64.862, S = 189.987, Phi = 159.100 } },
            { 2200, new ThermodynamicData { Cp = 34.949, H = 68.341, S = 191.605, Phi = 160.541 } },
            { 2300, new ThermodynamicData { Cp = 35.259, H = 71.851, S = 193.165, Phi = 161.926 } },
            { 2400, new ThermodynamicData { Cp = 35.555, H = 75.396, S = 194.672, Phi = 163.255 } },
            { 2500, new ThermodynamicData { Cp = 35.837, H = 78.969, S = 196.125, Phi = 164.545 } },
            { 2600, new ThermodynamicData { Cp = 36.106, H = 82.553, S = 197.540, Phi = 165.787 } },
            { 2700, new ThermodynamicData { Cp = 36.363, H = 86.170, S = 198.908, Phi = 166.988 } },
            { 2800, new ThermodynamicData { Cp = 36.610, H = 89.831, S = 200.235, Phi = 168.152 } },
            { 2900, new ThermodynamicData { Cp = 36.847, H = 93.504, S = 201.524, Phi = 169.281 } },
            { 3000, new ThermodynamicData { Cp = 37.076, H = 97.201, S = 202.776, Phi = 170.376 } },
            { 3100, new ThermodynamicData { Cp = 37.298, H = 100.919, S = 203.996, Phi = 171.441 } },
            { 3200, new ThermodynamicData { Cp = 37.513, H = 104.660, S = 205.183, Phi = 172.477 } },
            { 3300, new ThermodynamicData { Cp = 37.723, H = 108.422, S = 206.341, Phi = 173.486 } },
            { 3400, new ThermodynamicData { Cp = 37.928, H = 112.204, S = 207.470, Phi = 174.469 } },
            { 3500, new ThermodynamicData { Cp = 38.129, H = 116.002, S = 208.573, Phi = 175.426 } },
            { 3600, new ThermodynamicData { Cp = 38.326, H = 119.830, S = 209.649, Phi = 176.363 } },
            { 3700, new ThermodynamicData { Cp = 38.520, H = 123.672, S = 210.702, Phi = 177.277 } },
            { 3800, new ThermodynamicData { Cp = 38.711, H = 127.534, S = 211.732, Phi = 178.170 } },
            { 3900, new ThermodynamicData { Cp = 38.899, H = 131.414, S = 212.740, Phi = 179.044 } },
            { 4000, new ThermodynamicData { Cp = 39.085, H = 135.314, S = 213.727, Phi = 179.899 } },
            { 4100, new ThermodynamicData { Cp = 39.269, H = 139.231, S = 214.695, Phi = 180.736 } },
            { 4200, new ThermodynamicData { Cp = 39.450, H = 143.167, S = 215.643, Phi = 181.556 } },
            { 4300, new ThermodynamicData { Cp = 39.629, H = 147.121, S = 216.573, Phi = 182.359 } },
            { 4400, new ThermodynamicData { Cp = 39.806, H = 151.088, S = 217.486, Phi = 183.147 } },
            { 4500, new ThermodynamicData { Cp = 39.980, H = 155.089, S = 218.393, Phi = 183.923 } },
            { 4600, new ThermodynamicData { Cp = 40.151, H = 159.089, S = 219.264, Phi = 184.679 } },
            { 4700, new ThermodynamicData { Cp = 40.318, H = 163.126, S = 220.129, Phi = 185.424 } },
            { 4800, new ThermodynamicData { Cp = 40.482, H = 167.152, S = 220.979, Phi = 186.156 } },
            { 4900, new ThermodynamicData { Cp = 40.641, H = 171.208, S = 221.816, Phi = 186.875 } },
            { 5000, new ThermodynamicData { Cp = 40.796, H = 175.280, S = 222.638, Phi = 187.582 } },
            { 5100, new ThermodynamicData { Cp = 40.945, H = 179.368, S = 223.448, Phi = 188.278 } },
            { 5200, new ThermodynamicData { Cp = 41.088, H = 183.469, S = 224.244, Phi = 188.962 } },
            { 5300, new ThermodynamicData { Cp = 41.228, H = 187.586, S = 225.027, Phi = 189.633 } },
            { 5400, new ThermodynamicData { Cp = 41.357, H = 191.754, S = 225.804, Phi = 190.297 } },
            { 5500, new ThermodynamicData { Cp = 41.480, H = 195.856, S = 226.560, Phi = 190.950 } },
            { 5600, new ThermodynamicData { Cp = 41.596, H = 200.010, S = 227.308, Phi = 191.592 } },
            { 5700, new ThermodynamicData { Cp = 41.703, H = 204.175, S = 228.046, Phi = 192.225 } },
            { 5800, new ThermodynamicData { Cp = 41.803, H = 208.350, S = 228.772, Phi = 192.849 } },
            { 5900, new ThermodynamicData { Cp = 41.893, H = 212.535, S = 229.487, Phi = 193.464 } },
            { 6000, new ThermodynamicData { Cp = 41.974, H = 216.728, S = 230.192, Phi = 194.071 } },
            { 6200, new ThermodynamicData { Cp = 42.107, H = 225.137, S = 231.571, Phi = 195.258 } },
            { 6400, new ThermodynamicData { Cp = 42.200, H = 233.569, S = 232.909, Phi = 196.414 } },
            { 6600, new ThermodynamicData { Cp = 42.252, H = 242.015, S = 234.208, Phi = 197.540 } },
            { 6800, new ThermodynamicData { Cp = 42.263, H = 250.457, S = 235.470, Phi = 198.637 } },
            { 7000, new ThermodynamicData { Cp = 42.251, H = 258.917, S = 236.693, Phi = 199.707 } },
            { 7200, new ThermodynamicData { Cp = 42.164, H = 267.357, S = 237.884, Phi = 200.751 } },
            { 7400, new ThermodynamicData { Cp = 42.055, H = 275.788, S = 239.038, Phi = 201.770 } },
            { 7600, new ThermodynamicData { Cp = 41.910, H = 284.177, S = 240.157, Phi = 202.765 } },
            { 7800, new ThermodynamicData { Cp = 41.731, H = 292.542, S = 241.244, Phi = 203.738 } },
            { 8000, new ThermodynamicData { Cp = 41.520, H = 300.867, S = 242.298, Phi = 204.689 } },
            { 8200, new ThermodynamicData { Cp = 41.280, H = 309.148, S = 243.320, Phi = 205.619 } },
            { 8400, new ThermodynamicData { Cp = 41.014, H = 317.377, S = 244.312, Phi = 206.528 } },
            { 8600, new ThermodynamicData { Cp = 40.724, H = 325.559, S = 245.276, Phi = 207.417 } },
            { 8800, new ThermodynamicData { Cp = 40.418, H = 333.666, S = 246.206, Phi = 208.389 } },
            { 9000, new ThermodynamicData { Cp = 40.085, H = 341.716, S = 247.108, Phi = 209.427 } },
            { 9200, new ThermodynamicData { Cp = 39.745, H = 349.700, S = 247.988, Phi = 209.977 } },
            { 9400, new ThermodynamicData { Cp = 39.397, H = 357.614, S = 248.839, Phi = 210.795 } },
            { 9600, new ThermodynamicData { Cp = 39.027, H = 365.456, S = 249.664, Phi = 211.596 } },
            { 9800, new ThermodynamicData { Cp = 38.655, H = 373.224, S = 250.465, Phi = 212.381 } },
            { 10000, new ThermodynamicData { Cp = 38.277, H = 380.917, S = 251.242, Phi = 213.151 } },
            { 10500, new ThermodynamicData { Cp = 37.321, H = 399.818, S = 253.087, Phi = 215.009 } }
        };

    public static double[] GetTemperatureValuesH2()
    {
        return thermodynamicPropertiesH2.Keys.ToArray();
    }

    public static double GetPhiValuesForTemperatureH2(double temperature)
    {
        return thermodynamicPropertiesH2[temperature].Phi;
    }
    public static double[] GetCpValuesH2()
    {
        return thermodynamicPropertiesH2.Values.Select(data => data.Cp).ToArray();
    }

    public static double[] GetHValuesH2()
    {
        return thermodynamicPropertiesH2.Values.Select(data => data.H).ToArray();
    }

    public static double[] GetSValuesH2()
    {
        return thermodynamicPropertiesH2.Values.Select(data => data.S).ToArray();
    }

    public static double[] GetPhiValuesH2()
    {
        return thermodynamicPropertiesH2.Values.Select(data => data.Phi).ToArray();
    }

    public static double GetHValuesForTemperatureH2(double temperature)
    {
        return thermodynamicPropertiesH2[temperature].H;
    }
}