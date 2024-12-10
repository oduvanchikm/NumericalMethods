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

            { 10500, new ThermodynamicData { Cp = 37.321, H = 399.818, S = 253.087, Phi = 215.009 } },
            { 11000, new ThermodynamicData { Cp = 36.367, H = 418.239, S = 254.801, Phi = 216.779}}
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

    private static Dictionary<double, ThermodynamicData> thermodynamicPropertiesO2 =
        new Dictionary<double, ThermodynamicData>
        {
            { 100, new ThermodynamicData { Cp = 29.112, Phi = 144.182, S = 173.192, H = 2.901 } },
            { 200, new ThermodynamicData { Cp = 29.127, Phi = 164.310, S = 193.372, H = 5.812 } },
            { 298.15, new ThermodynamicData { Cp = 29.378, Phi = 175.921, S = 205.035, H = 8.680 } },
            { 300, new ThermodynamicData { Cp = 29.387, Phi = 176.101, S = 205.217, H = 8.735 } },
            { 400, new ThermodynamicData { Cp = 30.108, Phi = 184.495, S = 213.760, H = 11.706 } },
            { 500, new ThermodynamicData { Cp = 31.093, Phi = 191.052, S = 220.582, H = 14.765 } },
            { 600, new ThermodynamicData { Cp = 32.093, Phi = 196.465, S = 226.340, H = 17.925 } },
            { 700, new ThermodynamicData { Cp = 32.986, Phi = 201.099, S = 231.356, H = 21.180 } },
            { 800, new ThermodynamicData { Cp = 33.739, Phi = 205.165, S = 235.811, H = 24.517 } },
            { 900, new ThermodynamicData { Cp = 34.363, Phi = 208.796, S = 239.822, H = 27.923 } },
            { 1000, new ThermodynamicData { Cp = 34.880, Phi = 212.084, S = 243.471, H = 31.386 } },

            { 1100, new ThermodynamicData { Cp = 35.312, Phi = 215.092, S = 246.816, H = 34.897 } },
            { 1200, new ThermodynamicData { Cp = 35.681, Phi = 217.866, S = 249.904, H = 38.447 } },
            { 1300, new ThermodynamicData { Cp = 36.005, Phi = 220.442, S = 252.774, H = 42.031 } },
            { 1400, new ThermodynamicData { Cp = 36.296, Phi = 222.848, S = 255.453, H = 45.646 } },
            { 1500, new ThermodynamicData { Cp = 36.566, Phi = 225.106, S = 257.966, H = 49.290 } },
            { 1600, new ThermodynamicData { Cp = 36.822, Phi = 227.235, S = 260.334, H = 52.959 } },
            { 1700, new ThermodynamicData { Cp = 37.069, Phi = 229.248, S = 262.574, H = 56.654 } },
            { 1800, new ThermodynamicData { Cp = 37.310, Phi = 231.159, S = 264.700, H = 60.373 } },
            { 1900, new ThermodynamicData { Cp = 37.547, Phi = 232.978, S = 266.723, H = 64.116 } },
            { 2000, new ThermodynamicData { Cp = 37.783, Phi = 234.714, S = 268.655, H = 67.882 } },

            { 2100, new ThermodynamicData { Cp = 38.016, Phi = 236.375, S = 270.504, H = 71.672 } },
            { 2200, new ThermodynamicData { Cp = 38.248, Phi = 237.967, S = 272.278, H = 75.486 } },
            { 2300, new ThermodynamicData { Cp = 38.478, Phi = 239.496, S = 273.983, H = 79.322 } },
            { 2400, new ThermodynamicData { Cp = 38.705, Phi = 240.967, S = 275.626, H = 83.181 } },
            { 2500, new ThermodynamicData { Cp = 38.929, Phi = 242.385, S = 277.210, H = 87.063 } },
            { 2600, new ThermodynamicData { Cp = 39.150, Phi = 243.754, S = 278.741, H = 90.967 } },
            { 2700, new ThermodynamicData { Cp = 39.366, Phi = 245.078, S = 280.223, H = 94.893 } },
            { 2800, new ThermodynamicData { Cp = 39.578, Phi = 246.359, S = 281.659, H = 98.840 } },
            { 2900, new ThermodynamicData { Cp = 39.784, Phi = 247.600, S = 283.051, H = 102.808 } },
            { 3000, new ThermodynamicData { Cp = 39.986, Phi = 248.804, S = 284.403, H = 106.797 } },

            { 3100, new ThermodynamicData { Cp = 40.181, Phi = 249.974, S = 285.717, H = 110.805 } },
            { 3200, new ThermodynamicData { Cp = 40.371, Phi = 251.111, S = 286.996, H = 114.833 } },
            { 3300, new ThermodynamicData { Cp = 40.555, Phi = 252.218, S = 288.241, H = 118.879 } },
            { 3400, new ThermodynamicData { Cp = 40.734, Phi = 253.295, S = 289.455, H = 122.943 } },
            { 3500, new ThermodynamicData { Cp = 40.906, Phi = 254.345, S = 290.638, H = 127.025 } },
            { 3600, new ThermodynamicData { Cp = 41.074, Phi = 255.369, S = 291.793, H = 131.124 } },
            { 3700, new ThermodynamicData { Cp = 41.236, Phi = 256.369, S = 292.920, H = 135.240 } },
            { 3800, new ThermodynamicData { Cp = 41.393, Phi = 257.345, S = 294.022, H = 139.371 } },
            { 3900, new ThermodynamicData { Cp = 41.546, Phi = 258.300, S = 295.099, H = 143.518 } },
            { 4000, new ThermodynamicData { Cp = 41.695, Phi = 259.233, S = 296.153, H = 147.680 } },

            { 4100, new ThermodynamicData { Cp = 41.840, Phi = 260.146, S = 297.184, H = 151.856 } },
            { 4200, new ThermodynamicData { Cp = 41.981, Phi = 261.040, S = 298.194, H = 156.047 } },
            { 4300, new ThermodynamicData { Cp = 42.119, Phi = 261.916, S = 299.183, H = 160.251 } },
            { 4400, new ThermodynamicData { Cp = 42.253, Phi = 262.774, S = 300.153, H = 164.469 } },
            { 4500, new ThermodynamicData { Cp = 42.385, Phi = 263.615, S = 301.104, H = 168.700 } },
            { 4600, new ThermodynamicData { Cp = 42.515, Phi = 264.440, S = 302.036, H = 172.943 } },
            { 4700, new ThermodynamicData { Cp = 42.642, Phi = 265.250, S = 302.952, H = 177.200 } },
            { 4800, new ThermodynamicData { Cp = 42.767, Phi = 266.044, S = 303.850, H = 181.468 } },
            { 4900, new ThermodynamicData { Cp = 42.889, Phi = 266.825, S = 304.733, H = 185.748 } },
            { 5000, new ThermodynamicData { Cp = 43.009, Phi = 267.592, S = 305.600, H = 190.040 } },

            { 5100, new ThermodynamicData { Cp = 43.127, Phi = 268.345, S = 306.452, H = 194.344 } },
            { 5200, new ThermodynamicData { Cp = 43.243, Phi = 269.086, S = 307.290, H = 198.658 } },
            { 5300, new ThermodynamicData { Cp = 43.356, Phi = 269.815, S = 308.114, H = 202.983 } },
            { 5400, new ThermodynamicData { Cp = 43.467, Phi = 270.532, S = 308.924, H = 207.319 } },
            { 5500, new ThermodynamicData { Cp = 43.575, Phi = 271.237, S = 309.722, H = 211.664 } },
            { 5600, new ThermodynamicData { Cp = 43.680, Phi = 271.931, S = 310.506, H = 216.020 } },
            { 5700, new ThermodynamicData { Cp = 43.782, Phi = 272.615, S = 311.279, H = 220.384 } },
            { 5800, new ThermodynamicData { Cp = 43.881, Phi = 273.288, S = 312.039, H = 224.757 } },
            { 5900, new ThermodynamicData { Cp = 43.976, Phi = 273.951, S = 312.788, H = 229.139 } },
            { 6000, new ThermodynamicData { Cp = 44.067, Phi = 274.604, S = 313.526, H = 233.529 } },

            { 6200, new ThermodynamicData { Cp = 44.236, Phi = 275.883, S = 314.969, H = 242.329 } },
            { 6400, new ThermodynamicData { Cp = 44.386, Phi = 277.127, S = 316.370, H = 251.155 } },
            { 6600, new ThermodynamicData { Cp = 44.514, Phi = 278.336, S = 317.730, H = 260.000 } },
            { 6800, new ThermodynamicData { Cp = 44.620, Phi = 279.515, S = 319.053, H = 268.860 } },
            { 7000, new ThermodynamicData { Cp = 44.702, Phi = 280.663, S = 320.338, H = 277.728 } },

            { 7200, new ThermodynamicData { Cp = 44.758, Phi = 281.782, S = 321.588, H = 286.599 } },
            { 7400, new ThermodynamicData { Cp = 44.788, Phi = 282.874, S = 322.802, H = 295.466 } },
            { 7600, new ThermodynamicData { Cp = 44.792, Phi = 283.941, S = 323.983, H = 304.324 } },
            { 7800, new ThermodynamicData { Cp = 44.769, Phi = 284.982, S = 325.132, H = 313.166 } },
            { 8000, new ThermodynamicData { Cp = 44.721, Phi = 286.000, S = 326.248, H = 321.987 } },
            { 8200, new ThermodynamicData { Cp = 44.647, Phi = 286.995, S = 327.334, H = 330.779 } },

            { 8400, new ThermodynamicData { Cp = 44.549, Phi = 287.968, S = 328.398, H = 339.538 } },
            { 8600, new ThermodynamicData { Cp = 44.428, Phi = 288.920, S = 329.415, H = 348.258 } },
            { 8800, new ThermodynamicData { Cp = 44.286, Phi = 289.851, S = 330.412, H = 356.935 } },
            { 9000, new ThermodynamicData { Cp = 44.124, Phi = 290.763, S = 331.381, H = 365.562 } },
            { 9200, new ThermodynamicData { Cp = 43.944, Phi = 291.656, S = 332.322, H = 374.137 } },

            { 9400, new ThermodynamicData { Cp = 43.747, Phi = 292.531, S = 333.239, H = 382.655 } },
            { 9600, new ThermodynamicData { Cp = 43.536, Phi = 293.389, S = 334.130, H = 391.113 } },
            { 9800, new ThermodynamicData { Cp = 43.311, Phi = 294.229, S = 334.995, H = 399.508 } },
            { 10000, new ThermodynamicData { Cp = 43.075, Phi = 295.052, S = 335.836, H = 407.836 } },

            { 10500, new ThermodynamicData { Cp = 42.447, Phi = 297.042, S = 337.838, H = 428.356 } },
            { 11000, new ThermodynamicData { Cp = 41.782, Phi = 298.939, S = 339.705, H = 448.424}}
        };

    public static double[] GetTemperatureValuesO2()
    {
        return thermodynamicPropertiesO2.Keys.ToArray();
    }

    public static double GetPhiValuesForTemperatureO2(double temperature)
    {
        return thermodynamicPropertiesO2[temperature].Phi;
    }

    public static double[] GetCpValuesO2()
    {
        return thermodynamicPropertiesO2.Values.Select(data => data.Cp).ToArray();
    }

    public static double[] GetHValuesO2()
    {
        return thermodynamicPropertiesO2.Values.Select(data => data.H).ToArray();
    }

    public static double[] GetSValuesO2()
    {
        return thermodynamicPropertiesO2.Values.Select(data => data.S).ToArray();
    }

    public static double[] GetPhiValuesO2()
    {
        return thermodynamicPropertiesO2.Values.Select(data => data.Phi).ToArray();
    }

    public static double GetHValuesForTemperatureO2(double temperature)
    {
        return thermodynamicPropertiesO2[temperature].H;
    }

    private static Dictionary<double, ThermodynamicData> thermodynamicPropertiesH2O =
        new Dictionary<double, ThermodynamicData>
        {
            { 100, new ThermodynamicData { Cp = 33.310, Phi = 119.379, S = 152.271, H = 3.289 } },
            { 200, new ThermodynamicData { Cp = 33.354, Phi = 142.260, S = 175.370, H = 6.622 } },
            { 298.15, new ThermodynamicData { Cp = 33.609, Phi = 155.501, S = 188.724, H = 9.908 } },
            { 300, new ThermodynamicData { Cp = 33.618, Phi = 155.706, S = 188.930, H = 9.967 } },
            { 400, new ThermodynamicData { Cp = 34.146, Phi = 165.279, S = 198.715, H = 13.374 } },
            { 500, new ThermodynamicData { Cp = 35.071, Phi = 172.763, S = 206.425, H = 16.831 } },
            { 600, new ThermodynamicData { Cp = 36.289, Phi = 178.928, S = 212.924, H = 20.398 } },
            { 700, new ThermodynamicData { Cp = 37.606, Phi = 184.199, S = 218.617, H = 24.092 } },
            { 800, new ThermodynamicData { Cp = 38.942, Phi = 188.826, S = 223.726, H = 27.920 } },
            { 900, new ThermodynamicData { Cp = 40.261, Phi = 192.966, S = 228.389, H = 31.880 } },
            { 1000, new ThermodynamicData { Cp = 41.584, Phi = 196.727, S = 232.697, H = 35.971 } },

            { 1100, new ThermodynamicData { Cp = 42.782, Phi = 200.181, S = 236.716, H = 40.187 } },
            { 1200, new ThermodynamicData { Cp = 43.969, Phi = 203.385, S = 240.489, H = 44.525 } },
            { 1300, new ThermodynamicData { Cp = 45.105, Phi = 206.370, S = 244.054, H = 48.985 } },
            { 1400, new ThermodynamicData { Cp = 46.186, Phi = 209.190, S = 247.436, H = 53.545 } },
            { 1500, new ThermodynamicData { Cp = 47.215, Phi = 211.848, S = 250.658, H = 58.205 } },
            { 1600, new ThermodynamicData { Cp = 48.191, Phi = 214.352, S = 253.737, H = 62.952 } },
            { 1700, new ThermodynamicData { Cp = 49.117, Phi = 216.707, S = 256.686, H = 67.778 } },
            { 1800, new ThermodynamicData { Cp = 50.000, Phi = 218.921, S = 259.530, H = 72.672 } },
            { 2000, new ThermodynamicData { Cp = 51.600, Phi = 223.386, S = 264.824, H = 82.970 } },

            { 2100, new ThermodynamicData { Cp = 52.336, Phi = 225.422, S = 267.406, H = 88.167 } },
            { 2200, new ThermodynamicData { Cp = 53.030, Phi = 227.387, S = 269.857, H = 93.436 } },
            { 2300, new ThermodynamicData { Cp = 53.682, Phi = 229.285, S = 272.229, H = 98.782 } },
            { 2400, new ThermodynamicData { Cp = 54.296, Phi = 231.123, S = 274.527, H = 104.171 } },
            { 2500, new ThermodynamicData { Cp = 54.873, Phi = 232.904, S = 276.755, H = 109.669 } },
            { 2600, new ThermodynamicData { Cp = 55.415, Phi = 234.632, S = 278.918, H = 115.144 } },
            { 2700, new ThermodynamicData { Cp = 55.924, Phi = 236.311, S = 281.019, H = 120.711 } },
            { 2800, new ThermodynamicData { Cp = 56.402, Phi = 237.945, S = 283.062, H = 126.371 } },
            { 2900, new ThermodynamicData { Cp = 56.851, Phi = 239.535, S = 285.049, H = 131.991 } },
            { 3000, new ThermodynamicData { Cp = 57.274, Phi = 241.084, S = 286.983, H = 137.697 } },

            { 3100, new ThermodynamicData { Cp = 57.671, Phi = 242.596, S = 288.868, H = 143.445 } },
            { 3200, new ThermodynamicData { Cp = 58.046, Phi = 244.070, S = 290.705, H = 149.231 } },
            { 3300, new ThermodynamicData { Cp = 58.399, Phi = 245.511, S = 292.496, H = 155.053 } },
            { 3400, new ThermodynamicData { Cp = 58.732, Phi = 246.918, S = 294.245, H = 160.912 } },
            { 3500, new ThermodynamicData { Cp = 59.049, Phi = 248.295, S = 295.952, H = 166.799 } },
            { 3600, new ThermodynamicData { Cp = 59.349, Phi = 249.642, S = 297.620, H = 172.719 } },
            { 3700, new ThermodynamicData { Cp = 59.635, Phi = 250.961, S = 299.250, H = 178.668 } },
            { 3800, new ThermodynamicData { Cp = 59.909, Phi = 252.253, S = 300.844, H = 184.646 } },
            { 3900, new ThermodynamicData { Cp = 60.172, Phi = 253.519, S = 302.403, H = 190.650 } },
            { 4000, new ThermodynamicData { Cp = 60.427, Phi = 254.760, S = 303.930, H = 196.680 } },

            { 4100, new ThermodynamicData { Cp = 60.673, Phi = 255.978, S = 305.425, H = 202.735 } },
            { 4200, new ThermodynamicData { Cp = 60.914, Phi = 257.172, S = 306.890, H = 208.814 } },
            { 4300, new ThermodynamicData { Cp = 61.150, Phi = 258.345, S = 308.326, H = 214.917 } },
            { 4400, new ThermodynamicData { Cp = 61.384, Phi = 259.497, S = 309.735, H = 221.044 } },
            { 4500, new ThermodynamicData { Cp = 61.617, Phi = 260.629, S = 311.117, H = 227.198 } },
            { 4600, new ThermodynamicData { Cp = 61.849, Phi = 261.741, S = 312.474, H = 233.378 } },
            { 4700, new ThermodynamicData { Cp = 62.084, Phi = 262.835, S = 313.806, H = 239.564 } },
            { 4800, new ThermodynamicData { Cp = 62.322, Phi = 263.921, S = 315.116, H = 245.790 } },
            { 4900, new ThermodynamicData { Cp = 62.566, Phi = 264.969, S = 316.403, H = 252.029 } },
            { 5000, new ThermodynamicData { Cp = 62.816, Phi = 266.010, S = 317.670, H = 258.298 } },
            { 5100, new ThermodynamicData { Cp = 63.074, Phi = 267.035, S = 318.916, H = 264.592 } },

            { 5200, new ThermodynamicData { Cp = 63.343, Phi = 268.045, S = 320.144, H = 270.909 } },
            { 5300, new ThermodynamicData { Cp = 63.623, Phi = 269.040, S = 321.353, H = 277.261 } },
            { 5400, new ThermodynamicData { Cp = 63.893, Phi = 270.016, S = 322.528, H = 283.613 } },
            { 5500, new ThermodynamicData { Cp = 64.143, Phi = 270.978, S = 323.682, H = 289.868 } },
            { 5600, new ThermodynamicData { Cp = 64.365, Phi = 271.927, S = 324.823, H = 296.217 } },
            { 5700, new ThermodynamicData { Cp = 64.549, Phi = 272.865, S = 325.954, H = 302.663 } },
            { 5800, new ThermodynamicData { Cp = 64.721, Phi = 273.790, S = 327.088, H = 309.205 } },
            { 5900, new ThermodynamicData { Cp = 64.882, Phi = 274.703, S = 328.196, H = 315.607 } },
            { 6000, new ThermodynamicData { Cp = 65.030, Phi = 275.604, S = 329.288, H = 322.103 } },

            { 6200, new ThermodynamicData { Cp = 65.290, Phi = 277.370, S = 331.424, H = 335.136 } },
            { 6400, new ThermodynamicData { Cp = 65.499, Phi = 279.092, S = 333.501, H = 348.216 } },
            { 6600, new ThermodynamicData { Cp = 65.658, Phi = 280.771, S = 335.519, H = 361.332 } },
            { 6800, new ThermodynamicData { Cp = 65.767, Phi = 282.411, S = 337.481, H = 374.476 } },
            { 7000, new ThermodynamicData { Cp = 65.826, Phi = 284.011, S = 339.388, H = 387.636 } },

            { 7200, new ThermodynamicData { Cp = 65.883, Phi = 285.576, S = 341.243, H = 400.803 } },
            { 7400, new ThermodynamicData { Cp = 65.804, Phi = 287.104, S = 343.046, H = 413.968 } },
            { 7600, new ThermodynamicData { Cp = 65.726, Phi = 288.600, S = 344.800, H = 427.121 } },
            { 7800, new ThermodynamicData { Cp = 65.608, Phi = 290.063, S = 346.506, H = 440.264 } },
            { 8000, new ThermodynamicData { Cp = 65.452, Phi = 291.495, S = 348.165, H = 453.362 } },

            { 8200, new ThermodynamicData { Cp = 65.263, Phi = 292.897, S = 349.779, H = 466.434 } },
            { 8400, new ThermodynamicData { Cp = 65.044, Phi = 294.270, S = 351.349, H = 479.465 } },
            { 8600, new ThermodynamicData { Cp = 64.799, Phi = 295.615, S = 352.877, H = 492.450 } },
            { 8800, new ThermodynamicData { Cp = 64.533, Phi = 296.923, S = 354.364, H = 505.384 } },
            { 9000, new ThermodynamicData { Cp = 64.249, Phi = 298.206, S = 355.810, H = 518.262 } },

            { 9200, new ThermodynamicData { Cp = 63.951, Phi = 299.493, S = 357.219, H = 531.082 } },
            { 9400, new ThermodynamicData { Cp = 63.634, Phi = 300.736, S = 358.592, H = 543.839 } },
            { 9600, new ThermodynamicData { Cp = 63.332, Phi = 301.955, S = 359.928, H = 556.523 } },
            { 9800, new ThermodynamicData { Cp = 63.017, Phi = 303.152, S = 361.231, H = 569.174 } },
            { 10000, new ThermodynamicData { Cp = 62.705, Phi = 304.326, S = 362.501, H = 581.746 } },
            
            { 10500, new ThermodynamicData { Cp = 61.954, Phi = 307.169, S = 365.542, H = 612.909 } },
            { 11000, new ThermodynamicData { Cp = 61.276, Phi = 309.888, S = 368.408, H = 643.712 } }
        };

    public static double[] GetTemperatureValuesH2O()
    {
        return thermodynamicPropertiesH2O.Keys.ToArray();
    }

    public static double GetPhiValuesForTemperatureH2O(double temperature)
    {
        return thermodynamicPropertiesH2O[temperature].Phi;
    }

    public static double[] GetCpValuesH2O()
    {
        return thermodynamicPropertiesH2O.Values.Select(data => data.Cp).ToArray();
    }

    public static double[] GetHValuesH2O()
    {
        return thermodynamicPropertiesH2O.Values.Select(data => data.H).ToArray();
    }

    public static double[] GetSValuesH2O()
    {
        return thermodynamicPropertiesH2O.Values.Select(data => data.S).ToArray();
    }

    public static double[] GetPhiValuesH2O()
    {
        return thermodynamicPropertiesH2O.Values.Select(data => data.Phi).ToArray();
    }

    public static double GetHValuesForTemperatureH2O(double temperature)
    {
        return thermodynamicPropertiesH2O[temperature].H;
    }

    private static Dictionary<double, ThermodynamicData> thermodynamicPropertiesOH =
        new Dictionary<double, ThermodynamicData>
        {
            { 100, new ThermodynamicData { Cp = 31.628, Phi = 122.539, S = 149.978, H = 2.744 } },
            { 200, new ThermodynamicData { Cp = 30.515, Phi = 142.312, S = 171.579, H = 5.853 } },
            { 298.15, new ThermodynamicData { Cp = 29.886, Phi = 154.068, S = 183.682, H = 8.813 } },
            { 300, new ThermodynamicData { Cp = 29.864, Phi = 154.431, S = 184.046, H = 8.875 } },
            { 400, new ThermodynamicData { Cp = 29.604, Phi = 162.764, S = 192.351, H = 11.815 } },
            { 500, new ThermodynamicData { Cp = 29.494, Phi = 169.368, S = 198.957, H = 14.751 } },
            { 600, new ThermodynamicData { Cp = 29.619, Phi = 174.761, S = 204.347, H = 17.689 } },
            { 700, new ThermodynamicData { Cp = 29.651, Phi = 179.320, S = 208.893, H = 20.701 } },
            { 800, new ThermodynamicData { Cp = 29.655, Phi = 183.242, S = 212.815, H = 23.711 } },
            { 900, new ThermodynamicData { Cp = 30.265, Phi = 186.757, S = 216.161, H = 26.687 } },
            { 1000, new ThermodynamicData { Cp = 30.625, Phi = 189.887, S = 219.621, H = 29.734 } },

            { 1100, new ThermodynamicData { Cp = 31.153, Phi = 192.726, S = 222.566, H = 32.825 } },
            { 1200, new ThermodynamicData { Cp = 31.569, Phi = 195.337, S = 225.187, H = 35.956 } },
            { 1300, new ThermodynamicData { Cp = 32.069, Phi = 197.769, S = 227.482, H = 39.115 } },
            { 1400, new ThermodynamicData { Cp = 32.572, Phi = 200.058, S = 229.554, H = 42.294 } },
            { 1500, new ThermodynamicData { Cp = 33.103, Phi = 202.223, S = 231.421, H = 45.493 } },
            { 1600, new ThermodynamicData { Cp = 33.679, Phi = 204.285, S = 233.108, H = 48.708 } },
            { 1700, new ThermodynamicData { Cp = 34.114, Phi = 206.260, S = 234.638, H = 51.937 } },
            { 1800, new ThermodynamicData { Cp = 34.542, Phi = 208.161, S = 236.014, H = 55.179 } },
            { 1900, new ThermodynamicData { Cp = 34.966, Phi = 209.997, S = 237.248, H = 58.432 } },
            { 2000, new ThermodynamicData { Cp = 35.384, Phi = 211.767, S = 238.344, H = 61.696 } },

            { 2100, new ThermodynamicData { Cp = 35.934, Phi = 213.396, S = 239.294, H = 65.045 } },
            { 2200, new ThermodynamicData { Cp = 35.354, Phi = 215.196, S = 240.558, H = 68.396 } },
            { 2300, new ThermodynamicData { Cp = 36.280, Phi = 216.704, S = 245.146, H = 71.751 } },
            { 2400, new ThermodynamicData { Cp = 35.833, Phi = 218.120, S = 246.676, H = 75.118 } },
            { 2500, new ThermodynamicData { Cp = 36.181, Phi = 219.856, S = 248.576, H = 78.494 } },
            { 2600, new ThermodynamicData { Cp = 36.275, Phi = 221.135, S = 251.552, H = 81.884 } },
            { 2700, new ThermodynamicData { Cp = 36.623, Phi = 222.269, S = 252.476, H = 85.283 } },
            { 2800, new ThermodynamicData { Cp = 36.856, Phi = 223.397, S = 255.565, H = 88.691 } },
            { 2900, new ThermodynamicData { Cp = 36.858, Phi = 223.934, S = 255.565, H = 91.917 } },
            { 3000, new ThermodynamicData { Cp = 37.036, Phi = 223.937, S = 256.808, H = 98.612 } },

            { 3100, new ThermodynamicData { Cp = 37.206, Phi = 225.017, S = 258.025, H = 102.324 } },
            { 3200, new ThermodynamicData { Cp = 37.371, Phi = 226.067, S = 259.090, H = 106.053 } },
            { 3300, new ThermodynamicData { Cp = 37.530, Phi = 226.089, S = 260.361, H = 109.798 } },
            { 3400, new ThermodynamicData { Cp = 37.685, Phi = 227.054, S = 261.546, H = 113.486 } },
            { 3500, new ThermodynamicData { Cp = 37.835, Phi = 229.004, S = 262.846, H = 117.335 } },
            { 3600, new ThermodynamicData { Cp = 37.982, Phi = 230.004, S = 263.846, H = 120.126 } },
            { 3700, new ThermodynamicData { Cp = 38.125, Phi = 230.982, S = 265.340, H = 124.029 } },
            { 3800, new ThermodynamicData { Cp = 38.265, Phi = 231.826, S = 266.707, H = 128.751 } },
            { 3900, new ThermodynamicData { Cp = 38.406, Phi = 232.649, S = 268.070, H = 132.585 } },
            { 4000, new ThermodynamicData { Cp = 38.553, Phi = 233.569, S = 269.563, H = 136.431 } },

            { 4100, new ThermodynamicData { Cp = 38.666, Phi = 234.413, S = 268.630, H = 140.264 } },
            { 4200, new ThermodynamicData { Cp = 38.793, Phi = 235.239, S = 269.563, H = 144.164 } },
            { 4300, new ThermodynamicData { Cp = 38.940, Phi = 236.079, S = 271.374, H = 148.081 } },
            { 4400, new ThermodynamicData { Cp = 39.098, Phi = 236.840, S = 271.374, H = 151.948 } },
            { 4500, new ThermodynamicData { Cp = 39.254, Phi = 238.645, S = 274.116, H = 155.847 } },
            { 4600, new ThermodynamicData { Cp = 39.408, Phi = 239.950, S = 274.116, H = 159.760 } },
            { 4700, new ThermodynamicData { Cp = 39.569, Phi = 240.980, S = 276.050, H = 163.700 } },
            { 4800, new ThermodynamicData { Cp = 39.733, Phi = 241.649, S = 276.966, H = 167.654 } },
            { 4900, new ThermodynamicData { Cp = 39.892, Phi = 241.822, S = 276.566, H = 171.601 } },
            { 5000, new ThermodynamicData { Cp = 39.067, Phi = 241.988, S = 277.192, H = 179.542 } },

            { 5100, new ThermodynamicData { Cp = 39.766, Phi = 241.988, S = 277.192, H = 179.542 } },
            { 5200, new ThermodynamicData { Cp = 39.850, Phi = 242.673, S = 277.965, H = 183.523 } },
            { 5300, new ThermodynamicData { Cp = 39.927, Phi = 243.346, S = 278.725, H = 187.512 } },
            { 5400, new ThermodynamicData { Cp = 39.999, Phi = 244.008, S = 279.472, H = 191.508 } },
            { 5500, new ThermodynamicData { Cp = 40.063, Phi = 244.659, S = 280.207, H = 195.512 } },
            { 5600, new ThermodynamicData { Cp = 40.121, Phi = 245.301, S = 280.999, H = 199.521 } },
            { 5700, new ThermodynamicData { Cp = 40.172, Phi = 245.932, S = 281.640, H = 203.536 } },
            { 5800, new ThermodynamicData { Cp = 40.216, Phi = 246.554, S = 282.339, H = 207.555 } },
            { 5900, new ThermodynamicData { Cp = 40.252, Phi = 247.166, S = 283.027, H = 211.578 } },
            { 6000, new ThermodynamicData { Cp = 40.280, Phi = 247.769, S = 283.704, H = 215.605 } },

            { 6200, new ThermodynamicData { Cp = 40.315, Phi = 248.950, S = 285.025, H = 223.665 } },
            { 6400, new ThermodynamicData { Cp = 40.319, Phi = 250.097, S = 286.305, H = 231.729 } },
            { 6600, new ThermodynamicData { Cp = 40.292, Phi = 251.214, S = 287.545, H = 239.791 } },
            { 6800, new ThermodynamicData { Cp = 40.234, Phi = 252.301, S = 288.754, H = 247.850 } },
            { 7000, new ThermodynamicData { Cp = 40.148, Phi = 253.358, S = 289.942, H = 255.882 } },

            { 7200, new ThermodynamicData { Cp = 40.039, Phi = 254.387, S = 291.042, H = 263.906 } },
            { 7400, new ThermodynamicData { Cp = 39.892, Phi = 255.385, S = 292.132, H = 271.904 } },
            { 7600, new ThermodynamicData { Cp = 39.733, Phi = 256.355, S = 293.199, H = 279.886 } },
            { 7800, new ThermodynamicData { Cp = 39.539, Phi = 257.333, S = 294.222, H = 287.783 } },
            { 8000, new ThermodynamicData { Cp = 39.329, Phi = 258.368, S = 295.227, H = 295.670 } },

            { 8200, new ThermodynamicData { Cp = 39.101, Phi = 259.181, S = 296.195, H = 303.513 } },
            { 8400, new ThermodynamicData { Cp = 38.856, Phi = 260.033, S = 297.154, H = 311.350 } },
            { 8600, new ThermodynamicData { Cp = 38.602, Phi = 261.800, S = 298.090, H = 319.227 } },
            { 8800, new ThermodynamicData { Cp = 38.334, Phi = 263.022, S = 299.011, H = 326.748 } },
            { 9000, new ThermodynamicData { Cp = 38.050, Phi = 263.451, S = 299.903, H = 334.964 } },

            { 9200, new ThermodynamicData { Cp = 37.752, Phi = 264.516, S = 300.627, H = 341.984 } },
            { 9400, new ThermodynamicData { Cp = 37.454, Phi = 265.245, S = 301.422, H = 350.146 } },
            { 9600, new ThermodynamicData { Cp = 37.146, Phi = 265.865, S = 302.154, H = 357.650 } },
            { 9800, new ThermodynamicData { Cp = 36.831, Phi = 266.551, S = 302.915, H = 366.018 } },
            { 10000, new ThermodynamicData { Cp = 36.531, Phi = 266.551, S = 303.719, H = 371.682 } },

            { 10500, new ThermodynamicData { Cp = 35.749, Phi = 268.363, S = 305.483, H = 389.752 } },
            { 11000, new ThermodynamicData { Cp = 34.973, Phi = 270.088, S = 307.128, H = 407.432 } }
        };

    public static double[] GetTemperatureValuesOH()
    {
        return thermodynamicPropertiesOH.Keys.ToArray();
    }

    public static double GetPhiValuesForTemperatureOH(double temperature)
    {
        return thermodynamicPropertiesOH[temperature].Phi;
    }

    public static double[] GetCpValuesOH()
    {
        return thermodynamicPropertiesOH.Values.Select(data => data.Cp).ToArray();
    }

    public static double[] GetHValuesOH()
    {
        return thermodynamicPropertiesOH.Values.Select(data => data.H).ToArray();
    }

    public static double[] GetSValuesOH()
    {
        return thermodynamicPropertiesOH.Values.Select(data => data.S).ToArray();
    }

    public static double[] GetPhiValuesOH()
    {
        return thermodynamicPropertiesOH.Values.Select(data => data.Phi).ToArray();
    }

    public static double GetHValuesForTemperatureOH(double temperature)
    {
        return thermodynamicPropertiesOH[temperature].H;
    }

    private static Dictionary<double, ThermodynamicData> thermodynamicPropertiesH =
        new Dictionary<double, ThermodynamicData>
        {
            { 100, new ThermodynamicData { Cp = 20.786, Phi = 71.114, S = 91.900, H = 2.079 } },
            { 200, new ThermodynamicData { Cp = 20.786, Phi = 85.521, S = 106.307, H = 4.157 } },
            { 298.15, new ThermodynamicData { Cp = 20.786, Phi = 93.821, S = 114.604, H = 6.197 } },
            { 300, new ThermodynamicData { Cp = 20.786, Phi = 93.949, S = 114.735, H = 6.236 } },
            { 400, new ThermodynamicData { Cp = 20.786, Phi = 99.929, S = 120.715, H = 8.314 } },
            { 500, new ThermodynamicData { Cp = 20.786, Phi = 104.567, S = 125.353, H = 10.393 } },
            { 600, new ThermodynamicData { Cp = 20.786, Phi = 108.357, S = 129.143, H = 12.472 } },
            { 700, new ThermodynamicData { Cp = 20.786, Phi = 111.561, S = 132.347, H = 14.550 } },
            { 800, new ThermodynamicData { Cp = 20.786, Phi = 114.337, S = 135.123, H = 16.629 } },
            { 900, new ThermodynamicData { Cp = 20.786, Phi = 116.785, S = 137.571, H = 18.707 } },
            { 1000, new ThermodynamicData { Cp = 20.786, Phi = 118.975, S = 139.761, H = 20.786 } },

            { 1100, new ThermodynamicData { Cp = 20.786, Phi = 120.956, S = 141.742, H = 22.865 } },
            { 1200, new ThermodynamicData { Cp = 20.786, Phi = 122.765, S = 143.551, H = 24.943 } },
            { 1300, new ThermodynamicData { Cp = 20.786, Phi = 124.429, S = 145.215, H = 27.022 } },
            { 1400, new ThermodynamicData { Cp = 20.786, Phi = 125.969, S = 146.755, H = 29.100 } },
            { 1500, new ThermodynamicData { Cp = 20.786, Phi = 127.403, S = 148.189, H = 31.179 } },
            { 1600, new ThermodynamicData { Cp = 20.786, Phi = 128.745, S = 149.531, H = 33.258 } },
            { 1700, new ThermodynamicData { Cp = 20.786, Phi = 130.005, S = 150.791, H = 35.336 } },
            { 1800, new ThermodynamicData { Cp = 20.786, Phi = 131.193, S = 151.979, H = 37.415 } },
            { 1900, new ThermodynamicData { Cp = 20.786, Phi = 132.317, S = 153.103, H = 39.493 } },
            { 2000, new ThermodynamicData { Cp = 20.786, Phi = 133.383, S = 154.169, H = 41.572 } },

            { 2100, new ThermodynamicData { Cp = 20.786, Phi = 134.397, S = 155.183, H = 43.651 } },
            { 2200, new ThermodynamicData { Cp = 20.786, Phi = 135.364, S = 156.150, H = 45.729 } },
            { 2300, new ThermodynamicData { Cp = 20.786, Phi = 136.288, S = 157.074, H = 47.808 } },
            { 2400, new ThermodynamicData { Cp = 20.786, Phi = 137.173, S = 157.959, H = 49.886 } },
            { 2500, new ThermodynamicData { Cp = 20.786, Phi = 138.021, S = 158.807, H = 51.965 } },
            { 2600, new ThermodynamicData { Cp = 20.786, Phi = 138.837, S = 159.623, H = 54.044 } },
            { 2700, new ThermodynamicData { Cp = 20.786, Phi = 139.621, S = 160.407, H = 56.122 } },
            { 2800, new ThermodynamicData { Cp = 20.786, Phi = 140.377, S = 161.163, H = 58.201 } },
            { 2900, new ThermodynamicData { Cp = 20.786, Phi = 141.106, S = 161.892, H = 60.279 } },
            { 3000, new ThermodynamicData { Cp = 20.786, Phi = 141.811, S = 162.597, H = 62.358 } },

            { 3100, new ThermodynamicData { Cp = 20.786, Phi = 142.493, S = 163.279, H = 64.437 } },
            { 3200, new ThermodynamicData { Cp = 20.786, Phi = 143.153, S = 163.939, H = 66.515 } },
            { 3300, new ThermodynamicData { Cp = 20.786, Phi = 143.792, S = 164.578, H = 68.594 } },
            { 3400, new ThermodynamicData { Cp = 20.786, Phi = 144.413, S = 165.199, H = 70.672 } },
            { 3500, new ThermodynamicData { Cp = 20.786, Phi = 145.015, S = 165.801, H = 72.751 } },
            { 3600, new ThermodynamicData { Cp = 20.786, Phi = 145.601, S = 166.387, H = 74.830 } },
            { 3700, new ThermodynamicData { Cp = 20.786, Phi = 146.170, S = 166.956, H = 76.908 } },
            { 3800, new ThermodynamicData { Cp = 20.786, Phi = 146.725, S = 167.511, H = 78.987 } },
            { 3900, new ThermodynamicData { Cp = 20.786, Phi = 147.265, S = 168.050, H = 81.065 } },
            { 4000, new ThermodynamicData { Cp = 20.786, Phi = 147.791, S = 168.577, H = 83.144 } },

            { 4100, new ThermodynamicData { Cp = 20.786, Phi = 148.304, S = 169.090, H = 85.223 } },
            { 4200, new ThermodynamicData { Cp = 20.786, Phi = 148.805, S = 169.591, H = 87.301 } },
            { 4300, new ThermodynamicData { Cp = 20.786, Phi = 149.294, S = 170.080, H = 89.380 } },
            { 4400, new ThermodynamicData { Cp = 20.786, Phi = 149.772, S = 170.558, H = 91.458 } },
            { 4500, new ThermodynamicData { Cp = 20.786, Phi = 150.239, S = 171.025, H = 93.537 } },
            { 4600, new ThermodynamicData { Cp = 20.786, Phi = 150.696, S = 171.482, H = 95.616 } },
            { 4700, new ThermodynamicData { Cp = 20.786, Phi = 151.143, S = 171.929, H = 97.694 } },
            { 4800, new ThermodynamicData { Cp = 20.786, Phi = 151.581, S = 172.366, H = 99.773 } },
            { 4900, new ThermodynamicData { Cp = 20.786, Phi = 152.009, S = 172.795, H = 101.852 } },
            { 5000, new ThermodynamicData { Cp = 20.786, Phi = 152.429, S = 173.215, H = 103.930 } },

            { 5100, new ThermodynamicData { Cp = 20.786, Phi = 152.841, S = 173.627, H = 106.009 } },
            { 5200, new ThermodynamicData { Cp = 20.786, Phi = 153.244, S = 174.030, H = 108.087 } },
            { 5300, new ThermodynamicData { Cp = 20.786, Phi = 153.640, S = 174.426, H = 110.166 } },
            { 5400, new ThermodynamicData { Cp = 20.786, Phi = 154.029, S = 174.815, H = 112.245 } },
            { 5500, new ThermodynamicData { Cp = 20.786, Phi = 154.410, S = 175.196, H = 114.323 } },
            { 5600, new ThermodynamicData { Cp = 20.786, Phi = 154.785, S = 175.571, H = 116.402 } },
            { 5700, new ThermodynamicData { Cp = 20.786, Phi = 155.153, S = 175.939, H = 118.480 } },
            { 5800, new ThermodynamicData { Cp = 20.786, Phi = 155.514, S = 176.300, H = 120.559 } },
            { 5900, new ThermodynamicData { Cp = 20.786, Phi = 155.869, S = 176.655, H = 122.638 } },
            { 6000, new ThermodynamicData { Cp = 20.786, Phi = 156.219, S = 177.005, H = 124.716 } },

            { 6200, new ThermodynamicData { Cp = 20.786, Phi = 156.900, S = 177.686, H = 128.873 } },
            { 6400, new ThermodynamicData { Cp = 20.786, Phi = 157.560, S = 178.346, H = 133.031 } },
            { 6600, new ThermodynamicData { Cp = 20.786, Phi = 158.200, S = 178.986, H = 137.188 } },
            { 6800, new ThermodynamicData { Cp = 20.786, Phi = 158.820, S = 179.606, H = 141.345 } },
            { 7000, new ThermodynamicData { Cp = 20.786, Phi = 159.423, S = 180.209, H = 145.502 } },

            { 7200, new ThermodynamicData { Cp = 20.786, Phi = 160.009, S = 180.794, H = 149.659 } },
            { 7400, new ThermodynamicData { Cp = 20.786, Phi = 160.578, S = 181.364, H = 153.817 } },
            { 7600, new ThermodynamicData { Cp = 20.786, Phi = 161.132, S = 181.918, H = 157.974 } },
            { 7800, new ThermodynamicData { Cp = 20.786, Phi = 161.672, S = 182.458, H = 162.131 } },
            { 8000, new ThermodynamicData { Cp = 20.786, Phi = 162.199, S = 182.984, H = 166.288 } },

            { 8200, new ThermodynamicData { Cp = 20.786, Phi = 162.712, S = 183.498, H = 170.445 } },
            { 8400, new ThermodynamicData { Cp = 20.786, Phi = 163.213, S = 183.999, H = 174.603 } },
            { 8600, new ThermodynamicData { Cp = 20.786, Phi = 163.702, S = 184.498, H = 178.760 } },
            { 8800, new ThermodynamicData { Cp = 20.786, Phi = 164.180, S = 184.966, H = 182.917 } },
            { 9000, new ThermodynamicData { Cp = 20.786, Phi = 164.647, S = 185.433, H = 187.074 } },

            { 9200, new ThermodynamicData { Cp = 20.786, Phi = 165.104, S = 185.890, H = 191.231 } },
            { 9400, new ThermodynamicData { Cp = 20.786, Phi = 165.551, S = 186.337, H = 195.388 } },
            { 9600, new ThermodynamicData { Cp = 20.786, Phi = 165.988, S = 186.774, H = 199.546 } },
            { 9800, new ThermodynamicData { Cp = 20.786, Phi = 166.417, S = 187.204, H = 203.703 } },
            { 10000, new ThermodynamicData { Cp = 20.786, Phi = 166.837, S = 187.623, H = 207.860 } },

            { 10500, new ThermodynamicData { Cp = 20.786, Phi = 167.851, S = 188.637, H = 218.253 } },
            { 11000, new ThermodynamicData { Cp = 20.786, Phi = 168.818, S = 189.604, H = 228.646 } }
        };

    public static double[] GetTemperatureValuesH()
    {
        return thermodynamicPropertiesH.Keys.ToArray();
    }

    public static double GetPhiValuesForTemperatureH(double temperature)
    {
        return thermodynamicPropertiesH[temperature].Phi;
    }

    public static double[] GetCpValuesH()
    {
        return thermodynamicPropertiesH.Values.Select(data => data.Cp).ToArray();
    }

    public static double[] GetHValuesH()
    {
        return thermodynamicPropertiesH.Values.Select(data => data.H).ToArray();
    }

    public static double[] GetSValuesH()
    {
        return thermodynamicPropertiesH.Values.Select(data => data.S).ToArray();
    }

    public static double[] GetPhiValuesH()
    {
        return thermodynamicPropertiesH.Values.Select(data => data.Phi).ToArray();
    }

    public static double GetHValuesForTemperatureH(double temperature)
    {
        return thermodynamicPropertiesH[temperature].H;
    }

    private static Dictionary<double, ThermodynamicData> thermodynamicPropertiesO =
        new Dictionary<double, ThermodynamicData>
        {
            { 100, new ThermodynamicData { Cp = 23.703, Phi = 113.767, S = 135.837, H = 2.207 } },
            { 200, new ThermodynamicData { Cp = 22.734, Phi = 129.348, S = 152.043, H = 4.539 } },
            { 298, new ThermodynamicData { Cp = 21.911, Phi = 138.391, S = 160.946, H = 6.728 } },
            { 300, new ThermodynamicData { Cp = 21.901, Phi = 138.531, S = 161.084, H = 6.766 } },
            { 400, new ThermodynamicData { Cp = 21.482, Phi = 144.988, S = 167.320, H = 8.933 } },
            { 500, new ThermodynamicData { Cp = 21.257, Phi = 149.950, S = 172.087, H = 11.069 } },
            { 600, new ThermodynamicData { Cp = 21.124, Phi = 153.972, S = 175.950, H = 13.166 } },
            { 700, new ThermodynamicData { Cp = 21.040, Phi = 157.350, S = 179.200, H = 15.237 } },
            { 800, new ThermodynamicData { Cp = 20.984, Phi = 160.260, S = 182.005, H = 17.284 } },
            { 900, new ThermodynamicData { Cp = 20.944, Phi = 162.816, S = 184.474, H = 19.492 } },
            { 1000, new ThermodynamicData { Cp = 20.915, Phi = 165.094, S = 186.679, H = 21.585 } },

            { 1100, new ThermodynamicData { Cp = 20.893, Phi = 167.149, S = 188.672, H = 23.658 } },
            { 1200, new ThermodynamicData { Cp = 20.877, Phi = 169.019, S = 190.489, H = 25.713 } },
            { 1300, new ThermodynamicData { Cp = 20.864, Phi = 170.736, S = 192.160, H = 27.750 } },
            { 1400, new ThermodynamicData { Cp = 20.853, Phi = 172.322, S = 193.712, H = 29.771 } },
            { 1500, new ThermodynamicData { Cp = 20.845, Phi = 173.796, S = 195.162, H = 31.776 } },
            { 1600, new ThermodynamicData { Cp = 20.838, Phi = 175.173, S = 196.522, H = 33.765 } },
            { 1700, new ThermodynamicData { Cp = 20.833, Phi = 176.470, S = 197.812, H = 35.740 } },
            { 1800, new ThermodynamicData { Cp = 20.829, Phi = 177.694, S = 199.037, H = 37.700 } },
            { 1900, new ThermodynamicData { Cp = 20.826, Phi = 178.856, S = 200.207, H = 39.647 } },
            { 2000, new ThermodynamicData { Cp = 20.826, Phi = 179.918, S = 201.318, H = 41.583 } },

            { 2100, new ThermodynamicData { Cp = 20.827, Phi = 180.953, S = 202.153, H = 44.521 } },
            { 2200, new ThermodynamicData { Cp = 20.830, Phi = 181.939, S = 203.122, H = 46.604 } },
            { 2300, new ThermodynamicData { Cp = 20.835, Phi = 182.880, S = 204.048, H = 48.687 } },
            { 2400, new ThermodynamicData { Cp = 20.841, Phi = 183.780, S = 204.935, H = 50.771 } },
            { 2500, new ThermodynamicData { Cp = 20.851, Phi = 184.653, S = 205.786, H = 52.855 } },
            { 2600, new ThermodynamicData { Cp = 20.862, Phi = 185.473, S = 206.604, H = 54.941 } },
            { 2700, new ThermodynamicData { Cp = 20.877, Phi = 186.270, S = 207.392, H = 57.026 } },
            { 2800, new ThermodynamicData { Cp = 20.894, Phi = 187.038, S = 208.151, H = 59.116 } },
            { 2900, new ThermodynamicData { Cp = 20.914, Phi = 187.779, S = 208.885, H = 61.207 } },
            { 3000, new ThermodynamicData { Cp = 20.937, Phi = 188.494, S = 209.594, H = 63.299 } },

            { 3100, new ThermodynamicData { Cp = 20.963, Phi = 189.186, S = 210.281, H = 65.394 } },
            { 3200, new ThermodynamicData { Cp = 20.991, Phi = 189.856, S = 210.947, H = 67.492 } },
            { 3300, new ThermodynamicData { Cp = 21.022, Phi = 190.505, S = 211.593, H = 69.593 } },
            { 3400, new ThermodynamicData { Cp = 21.056, Phi = 191.134, S = 212.221, H = 71.697 } },
            { 3500, new ThermodynamicData { Cp = 21.092, Phi = 191.746, S = 212.832, H = 73.804 } },
            { 3600, new ThermodynamicData { Cp = 21.130, Phi = 192.340, S = 213.427, H = 75.915 } },
            { 3700, new ThermodynamicData { Cp = 21.170, Phi = 192.917, S = 214.007, H = 78.030 } },
            { 3800, new ThermodynamicData { Cp = 21.213, Phi = 193.480, S = 214.572, H = 80.149 } },
            { 3900, new ThermodynamicData { Cp = 21.257, Phi = 194.028, S = 215.123, H = 82.273 } },
            { 4000, new ThermodynamicData { Cp = 21.302, Phi = 194.562, S = 215.662, H = 84.401 } },

            { 4100, new ThermodynamicData { Cp = 21.349, Phi = 195.083, S = 216.189, H = 86.533 } },
            { 4200, new ThermodynamicData { Cp = 21.397, Phi = 195.592, S = 216.704, H = 88.670 } },
            { 4300, new ThermodynamicData { Cp = 21.445, Phi = 196.088, S = 217.208, H = 90.812 } },
            { 4400, new ThermodynamicData { Cp = 21.495, Phi = 196.574, S = 217.701, H = 92.959 } },
            { 4500, new ThermodynamicData { Cp = 21.545, Phi = 197.049, S = 218.185, H = 95.111 } },
            { 4600, new ThermodynamicData { Cp = 21.596, Phi = 197.514, S = 218.659, H = 97.268 } },
            { 4700, new ThermodynamicData { Cp = 21.647, Phi = 197.968, S = 219.123, H = 99.431 } },
            { 4800, new ThermodynamicData { Cp = 21.697, Phi = 198.414, S = 219.580, H = 101.598 } },
            { 4900, new ThermodynamicData { Cp = 21.748, Phi = 198.851, S = 220.028, H = 103.770 } },
            { 5000, new ThermodynamicData { Cp = 21.799, Phi = 199.279, S = 220.468, H = 105.947 } },

            { 5100, new ThermodynamicData { Cp = 21.849, Phi = 199.698, S = 220.900, H = 108.130 } },
            { 5200, new ThermodynamicData { Cp = 21.899, Phi = 200.110, S = 221.325, H = 110.317 } },
            { 5300, new ThermodynamicData { Cp = 21.949, Phi = 200.514, S = 221.744, H = 112.508 } },
            { 5400, new ThermodynamicData { Cp = 21.997, Phi = 200.911, S = 222.153, H = 114.707 } },
            { 5500, new ThermodynamicData { Cp = 22.045, Phi = 201.301, S = 222.557, H = 116.910 } },
            { 5600, new ThermodynamicData { Cp = 22.093, Phi = 201.684, S = 222.957, H = 119.111 } },
            { 5700, new ThermodynamicData { Cp = 22.139, Phi = 202.061, S = 223.346, H = 121.326 } },
            { 5800, new ThermodynamicData { Cp = 22.184, Phi = 202.431, S = 223.732, H = 123.544 } },
            { 5900, new ThermodynamicData { Cp = 22.229, Phi = 202.795, S = 224.112, H = 125.764 } },
            { 6000, new ThermodynamicData { Cp = 22.273, Phi = 203.154, S = 224.485, H = 127.990 } },

            { 6200, new ThermodynamicData { Cp = 22.356, Phi = 203.854, S = 225.217, H = 132.452 } },
            { 6400, new ThermodynamicData { Cp = 22.436, Phi = 204.533, S = 225.928, H = 136.932 } },
            { 6600, new ThermodynamicData { Cp = 22.510, Phi = 205.192, S = 226.620, H = 141.426 } },
            { 6800, new ThermodynamicData { Cp = 22.581, Phi = 205.832, S = 227.293, H = 145.936 } },
            { 7000, new ThermodynamicData { Cp = 22.646, Phi = 206.454, S = 227.950, H = 150.458 } },

            { 7200, new ThermodynamicData { Cp = 22.707, Phi = 207.060, S = 228.587, H = 154.994 } },
            { 7400, new ThermodynamicData { Cp = 22.763, Phi = 207.650, S = 229.218, H = 159.541 } },
            { 7600, new ThermodynamicData { Cp = 22.814, Phi = 208.226, S = 229.818, H = 164.099 } },
            { 7800, new ThermodynamicData { Cp = 22.861, Phi = 208.787, S = 230.411, H = 168.683 } },
            { 8000, new ThermodynamicData { Cp = 22.904, Phi = 209.335, S = 230.990, H = 173.246 } },

            { 8200, new ThermodynamicData { Cp = 22.943, Phi = 209.870, S = 231.556, H = 177.827 } },
            { 8400, new ThermodynamicData { Cp = 22.972, Phi = 210.393, S = 232.116, H = 182.419 } },
            { 8600, new ThermodynamicData { Cp = 23.009, Phi = 210.904, S = 232.651, H = 187.018 } },
            { 8800, new ThermodynamicData { Cp = 23.036, Phi = 211.404, S = 233.165, H = 191.623 } },
            { 9000, new ThermodynamicData { Cp = 23.061, Phi = 211.894, S = 233.698, H = 196.230 } },

            { 9200, new ThermodynamicData { Cp = 23.082, Phi = 212.374, S = 234.205, H = 200.845 } },
            { 9400, new ThermodynamicData { Cp = 23.100, Phi = 212.844, S = 234.702, H = 205.465 } },
            { 9600, new ThermodynamicData { Cp = 23.115, Phi = 213.312, S = 235.188, H = 210.086 } },
            { 9800, new ThermodynamicData { Cp = 23.127, Phi = 213.756, S = 235.665, H = 214.711 } },
            { 10000, new ThermodynamicData { Cp = 23.137, Phi = 214.198, S = 236.132, H = 219.337 } },

            { 10500, new ThermodynamicData { Cp = 23.153, Phi = 215.270, S = 237.261, H = 230.910 } },
            { 11000, new ThermodynamicData { Cp = 23.156, Phi = 216.294, S = 238.339, H = 242.488 } }
        };

    public static double[] GetTemperatureValuesO()
    {
        return thermodynamicPropertiesO.Keys.ToArray();
    }

    public static double GetPhiValuesForTemperatureO(double temperature)
    {
        return thermodynamicPropertiesO[temperature].Phi;
    }

    public static double[] GetCpValuesO()
    {
        return thermodynamicPropertiesO.Values.Select(data => data.Cp).ToArray();
    }

    public static double[] GetHValuesO()
    {
        return thermodynamicPropertiesO.Values.Select(data => data.H).ToArray();
    }

    public static double[] GetSValuesO()
    {
        return thermodynamicPropertiesO.Values.Select(data => data.S).ToArray();
    }

    public static double[] GetPhiValuesO()
    {
        return thermodynamicPropertiesO.Values.Select(data => data.Phi).ToArray();
    }

    public static double GetHValuesForTemperatureO(double temperature)
    {
        return thermodynamicPropertiesO[temperature].H;
    }
}
