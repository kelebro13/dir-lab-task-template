module.exports = {
  env: {
    es6: true,
    browser: true,
    commonjs: true
  },
  extends: [
    "eslint:recommended",
    "plugin:@typescript-eslint/eslint-recommended",
    "plugin:@typescript-eslint/recommended",
    "plugin:react/recommended",
  ],
  parser: "@typescript-eslint/parser",
  parserOptions: {
    jsx: true,
    useJSXTextNode: true,
    ecmaVersion: 6,
    sourceType: "module",
    project: "./tsconfig.json"
  },
  rules: {
    "react/prop-types": 0,
    "@typescript-eslint/naming-convention": [
      "error",
      {
        "selector": "interface",
        "format": ["PascalCase"],
        "custom": {
          "regex": "^I[A-Z]",
          "match": true
        }
      }
    ],
    "@typescript-eslint/explicit-function-return-type": "off",
    "@typescript-eslint/no-var-requires": "off"
  },
  plugins: ["@typescript-eslint", "react"],
  settings: {
    react: {
      version: "16"
    }
  }
}
