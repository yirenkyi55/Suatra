import { CategoryEffects } from './categories.effects';
import { SubCategoryEffects } from './sub-categories.effects';
import { TopicEffects } from './topics.effects';

export const effects: any[] = [
  CategoryEffects,
  SubCategoryEffects,
  TopicEffects,
];

export * from './categories.effects';
export * from './sub-categories.effects';
export * from './topics.effects';
