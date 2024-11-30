export const validateFirstName = (value) => {
    if (!value) return "First name is required";
    if (value.length < 3 || value.length >= 30) return "First name should contain 3 to 30 characters";
    return "";
};

