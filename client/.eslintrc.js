module.exports = {
  env: {
    es6: true,
    browser: true,
    commonjs: true,
    jest: true,
  },
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/eslint-recommended',
    'plugin:@typescript-eslint/recommended',
    'plugin:react/recommended',
    'prettier'
  ],
  parser: '@typescript-eslint/parser',
  parserOptions: {
    jsx: true,
    useJSXTextNode: true,
    ecmaVersion: 6,
    sourceType: 'module',
    project: './tsconfig.json',
  },
  rules: {
    'no-console': 'error',
    'react/prop-types': 0,
    '@typescript-eslint/naming-convention': [
      'error',
      {
        selector: 'interface',
        format: ['PascalCase'],
        custom: {
          regex: '^I[A-Z]',
          match: true,
        },
      },
    ],
    '@typescript-eslint/explicit-function-return-type': 'off',
    '@typescript-eslint/no-var-requires': 'off',
    "react/sort-comp": ["error", {
      order: [
        'static-methods',
        'lifecycle',
        'everything-else',
        'render',
      ],
    }],
    "react/jsx-boolean-value": ["error", "always"],
    "react/jsx-curly-spacing": ["error", "never"],
    "react/jsx-equals-spacing": ["error", "never"],
    "react/jsx-indent": ["error", 2],
    "react/jsx-indent-props": ["error", 2],
    "react/jsx-key": "error",
    "react/jsx-pascal-case": "error",
    "react/jsx-tag-spacing": ["error", {
      "closingSlash": "never",
      "beforeSelfClosing": "always",
      "afterOpening": "never"
    }],
    "react/jsx-no-bind": ["error", {
      "ignoreRefs": true,
      "allowArrowFunctions": true,
      "allowBind": false
    }],
    "react/jsx-closing-bracket-location": ["error", "after-props"],
  },
  plugins: ['@typescript-eslint', 'react'],
  settings: {
    react: {
      version: '16',
    },
  }
};
