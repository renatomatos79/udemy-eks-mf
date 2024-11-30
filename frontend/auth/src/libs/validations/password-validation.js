export const validatePassword = (value) => {
    if (!value) return "Password is required";
    if (value.length < 6 || value.length > 10) return "Password should contain 6 to 10 characters";
    return "";
};

export const validateConfirmPassword = (source, value) => {
    if (!value) return "Confirm password is required";
    if (value !== source) return "Password must be identical";
    return "";
};