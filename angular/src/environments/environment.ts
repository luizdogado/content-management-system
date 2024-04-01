import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Content Management System',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44357/',
    redirectUri: baseUrl,
    clientId: 'ContentManagementSystem_App',
    responseType: 'code',
    scope: 'offline_access ContentManagementSystem',
    requireHttps: true,
  },
  apis: {
    HtmlContent: {
      rootNamespace: 'HtmlContent',
    },
    default: {
      url: 'https://localhost:44357',
      rootNamespace: 'Content Management System',
    },
  },
} as Environment;
