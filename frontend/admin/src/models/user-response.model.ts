export class UserResponseModel {
    id: string;
    name: string;
    email: string;
    roles: string[];
    isBlocked: boolean;
    isActive: boolean;
    imageUrl: string;
}