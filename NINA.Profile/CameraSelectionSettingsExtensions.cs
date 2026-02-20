#region "copyright"

/*
    Copyright © 2016 - 2026 Stefan Berg <isbeorn86+NINA@googlemail.com> and the N.I.N.A. contributors

    This file is part of N.I.N.A. - Nighttime Imaging 'N' Astronomy.

    This Source Code Form is subject to the terms of the Mozilla Public
    License, v. 2.0. If a copy of the MPL was not distributed with this
    file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#endregion "copyright"

using NINA.Profile.Interfaces;

namespace NINA.Profile {

    public static class CameraSelectionSettingsExtensions {

        public static string GetImagingCameraId(this IProfile profile) {
            return GetConfiguredCameraId(profile?.ImageSettings?.ImagingCameraId, profile?.CameraSettings?.Id);
        }

        public static string GetPlateSolvingCameraId(this IProfile profile) {
            return GetConfiguredCameraId(profile?.PlateSolveSettings?.CameraId, profile?.CameraSettings?.Id);
        }

        public static string GetAutoFocusCameraId(this IProfile profile) {
            return GetConfiguredCameraId(profile?.FocuserSettings?.AutoFocusCameraId, profile?.CameraSettings?.Id);
        }

        private static string GetConfiguredCameraId(string configuredId, string fallbackCameraId) {
            if (string.IsNullOrWhiteSpace(configuredId) || configuredId == "No_Device") {
                return fallbackCameraId;
            }

            return configuredId;
        }
    }
}
