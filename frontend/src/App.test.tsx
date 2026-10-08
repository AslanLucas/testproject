import { render, screen } from '@testing-library/react'
import App from './App'

// Nur zum Prüfen, dass Vitest + Testing Library laufen.
test('zeigt die Überschrift', () => {
  render(<App />)
  expect(screen.getByRole('heading', { name: 'BestGuide' })).toBeInTheDocument()
})
