export const configuration = () => ({
    NODE_ENV: process.env.NODE_ENV,
    profile: {
        message: process.env.PROFILE_MESSAGE
    },
    database: {
        host: process.env.DATABASE_HOST,
        serviceName: process.env.DATABASE_SERVICE,
        username: process.env.DATABASE_USERNAME,
        password: process.env.DATABASE_PASSWORD
    }
});